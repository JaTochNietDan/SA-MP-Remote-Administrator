/*-----------------------------------------------------------------------------
	Title: 			Remote Administrator - The Ultimate Remote Admin Tool
	Version:		0.1
	Author: 		JaTochNietDan (http://www.jatochnietdan.com)
	Description:
					Remote Administrator is a tool for San Andreas Multiplayer
					server owners and administrators to manage their server
					remotely. It expands upon the basic capability of the
					standard RCON functionality of the server and enhances
					the amount of control you have over your server
					remotely.

	Credits to:
					BlueG for his Sockets plugin.
-------------------------------------------------------------------------------*/
#include <a_samp>
#include <socket>

/*******************************
*							   *
*	DEFINE ADMINISTRATOR LEVELS*
*							   *
********************************/
#define KICK_LEVEL 1
#define BAN_LEVEL 3

#define INFO_LEVEL 1
#define SKIN_LEVEL 2
#define HEALTH_LEVEL 2
#define ARMOUR_LEVEL 2
#define WEAPON_LEVEL 2
#define SCORE_LEVEL 2
#define INTERIOR_LEVEL 3
#define WORLD_LEVEL 3
#define VHEALTH_LEVEL 2

#define ADMIN_MANAGE 5
#define BAN_MANAGE 4

/*******************************
*							   *
*	DEFINE DATABASE SETTINGS   *
*		 (OPTIONAL)			   *
*							   *
********************************/
#define SOCKET_PORT 9890
#define MAX_CONNECTIONS 5

// Uncomment this define if you have a bind error.
//#define SOCKET_BIND "127.0.0.1"

#define DB_NAME remoteadmin.db
#define ADMIN_TABLE admins
#define BAN_TABLE bans

/*******************************
*							   *
*	DEFINE COLOURS			   *
*							   *
********************************/
#define ADMIN_COLOUR 0xFF0000FF
#define ACTION_COLOUR 0xFF7575FF
#define CHAT_COLOUR 0xFFFFFFAA

#define ADMIN_COLOUR_D FF0000
#define CHAT_COLOUR_D FFFFFF
#define ACTION_COLOUR_D FF7575
#define AFFECT_COLOUR_D 6699FF

#define MAX_QUERY_LENGTH 500

new 
	Socket:gSocket,
	DB:gDB,
	DBResult:gResult;

new 
	bool:bLogged[MAX_CONNECTIONS],
	strRANames[MAX_CONNECTIONS][24],
	iLevel[MAX_CONNECTIONS];

new player_count = 0;

new 
	strNames[MAX_PLAYERS][MAX_PLAYER_NAME],
	strIP[MAX_PLAYERS][16],
	gQuery[MAX_QUERY_LENGTH],
	bool:paused[MAX_PLAYERS],
	bool:lastmove[MAX_PLAYERS],
	bool:isbanned[MAX_PLAYERS];
	
new globaltimer;

new strPlayerlist[(MAX_PLAYER_NAME + 10) * MAX_PLAYERS];

forward checkPaused();
forward kickPlayer(playerid);

main() {}

public OnFilterScriptInit()
{
	for(new i; i < MAX_PLAYERS; i++)
	{
		if(!IsPlayerConnected(i)) continue;
		
		GetPlayerName(i, strNames[i], MAX_PLAYER_NAME);
		GetPlayerIp(i, strIP[i], 16);
	}

	gDB = db_open(""#DB_NAME"");

	db_free_result(db_query(gDB,
		"CREATE TABLE IF NOT EXISTS \""#ADMIN_TABLE"\" ("\
		"\"ID\"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,"\
		"\"user_name\"  TEXT(24) NOT NULL,"\
		"\"user_password\"  TEXT(32) NOT NULL,"\
		"\"user_level\"  INTEGER NOT NULL);"));
		
	db_free_result(db_query(gDB,
		"CREATE TABLE IF NOT EXISTS \""#BAN_TABLE"\" ("\
		"\"ID\"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,"\
		"\"user_banned\"  TEXT(24) NOT NULL,"\
		"\"user_banned_ip\"  TEXT(16) NOT NULL,"\
		"\"user_banner\"  TEXT(24) NOT NULL,"\
		"\"ban_reason\"  TEXT(40) NOT NULL DEFAULT 'None',"\
		"\"ban_timestamp\"  INT(10) NOT NULL,"\
		"\"ban_time\"  INTEGER NOT NULL);"));
		
	gResult = db_query(gDB, "SELECT ID FROM `"#ADMIN_TABLE"` LIMIT 0,1");
	
	if(db_num_rows(gResult) == 0) db_free_result(db_query(gDB, "INSERT INTO `"#ADMIN_TABLE"` (user_name, user_password, user_level) VALUES ('admin', '21232F297A57A5A743894A0E4A801FC3', '5')"));

	gSocket = socket_create(TCP);
	socket_set_max_connections(gSocket, MAX_CONNECTIONS);
	
	#if defined SOCKET_BIND
		socket_bind(gSocket, SOCKET_BIND);
	#endif
	
	socket_listen(gSocket, SOCKET_PORT);
	
	globaltimer = SetTimer("checkPaused", 3000, true);
	return 1;
}

public OnFilterScriptExit()
{
	socket_stop_listen(gSocket);
	socket_destroy(gSocket);
	
	KillTimer(globaltimer);
	return 1;
}

public checkPaused()
{
	for(new i; i < MAX_PLAYERS; i++)
	{
		if(!IsPlayerConnected(i)) continue;
		
		if(lastmove[i]) paused[i] = false;
		else paused[i] = true;
		
		lastmove[i] = false;
	}	
	return 1;
}

public OnPlayerUpdate(playerid)
{
	lastmove[playerid] = true;
	return 1;
}

public onSocketRemoteConnect(Socket:id, remote_client[], remote_clientid)
{
	return 1;
}

public onSocketReceiveData(Socket:id, remote_clientid, data[], data_len)
{
	new splitdata[3][128];
	
	ra_sscanf(data, "p:sss", splitdata[0], splitdata[1], splitdata[2]);
	
	if(splitdata[0][0] == 'i' && strlen(splitdata[2])) ra_sscanf(splitdata[2], "p:sss", splitdata[0], splitdata[1], splitdata[2]);
	
	if(splitdata[0][0] == 'i')
	{
		new iID;
		
		ra_sscanf(data, "p:sus", splitdata[0], iID, splitdata[2]);
		
		if(iID == INVALID_PLAYER_ID) sendToClient(remote_clientid, "amsg:The player you specified was not found!");
		else
		{
			new
				Float: health,
				Float: armour,
				Float: vhealth,
				Float: cx,
				Float: cy,
				Float: cz,
				Float: ca,
				Float: cvx,
				Float: cvy,
				Float: cvz,
				vmodel,
				playerstate,
				vid;
				
			if(IsPlayerInAnyVehicle(iID)) 
			{
				vid = GetPlayerVehicleID(iID);
			
				GetVehicleHealth(vid, vhealth);
				vmodel = GetVehicleModel(vid);
				
				GetVehiclePos(vid, cx, cy, cz);
				GetVehicleZAngle(vid, ca);
				
				GetVehicleVelocity(vid, cvx, cvy, cvz);
			}
			else
			{
				GetPlayerPos(iID, cx, cy, cz);
				GetPlayerFacingAngle(iID, ca);
				
				GetPlayerVelocity(vid, cvx, cvy, cvz);
			}
			
			if(paused[iID]) playerstate = -1;
			else playerstate = GetPlayerState(iID);
			
			GetPlayerHealth(iID, health);
			GetPlayerArmour(iID, armour);																																										
		
			format(gQuery, sizeof(gQuery), "info:%i:%i:%i:%i:%i:%i:%i:%i:%i:%f:%f:%f:%f:%f:%f:%f:%i", vmodel, GetPlayerSkin(iID), GetPlayerVirtualWorld(iID), GetPlayerInterior(iID), GetPlayerWeapon(iID), GetPlayerScore(iID), floatround(health), floatround(armour), floatround(vhealth), cx, cy, cz, ca, cvx, cvy, cvz, playerstate);
		
			sendToClient(remote_clientid, gQuery);
		}
	}
	else if(strcmp(splitdata[0], "login", true) == 0)
	{
		new lResult = checkUserCredentials(remote_clientid, splitdata[1], splitdata[2]);
		
		if(lResult != -1)
		{
			bLogged[remote_clientid] = true;
			
			sendPermissionsToClient(remote_clientid);
			sendPlayerListToClient(remote_clientid);
		}
		else sendToClient(remote_clientid, "log:fail");
	}
	else if(!bLogged[remote_clientid]) return 1;
	else if(strcmp(splitdata[0], "msg", true) == 0)
	{
		format(gQuery, sizeof(gQuery), "{"#ADMIN_COLOUR_D"}%s on RA: {"#CHAT_COLOUR_D"}%s", splitdata[1], splitdata[2]);
		SendClientMessageToAll(CHAT_COLOUR, gQuery);
		
		format(gQuery, sizeof(gQuery), "xmsg:%s:%s", splitdata[1], splitdata[2]);
		sendToAllButClient(remote_clientid, gQuery);
	}
	else if(strcmp(splitdata[0], "kick", true) == 0)
	{
		if(iLevel[remote_clientid] < KICK_LEVEL) sendToClient(remote_clientid, "amsg:You are not a high enough level");
		else
		{
			new iID;
		
			ra_sscanf(data, "p:sus", splitdata[0], iID, splitdata[2]);
			
			if(iID == INVALID_PLAYER_ID) sendToClient(remote_clientid, "amsg:The player you specified was not found!");
			else
			{
				if(strlen(splitdata[2]) > 0)
					format(gQuery, sizeof(gQuery), "-[{"#AFFECT_COLOUR_D"}(%d) %s{"#ACTION_COLOUR_D"} has been kicked by remote admin {"#AFFECT_COLOUR_D"}%s {"#ACTION_COLOUR_D"}(Reason: %s)]-", iID, strNames[iID], strRANames[remote_clientid], splitdata[2]);
				else
					format(gQuery, sizeof(gQuery), "-[{"#AFFECT_COLOUR_D"}(%d) %s{"#ACTION_COLOUR_D"} has been kicked by remote admin {"#AFFECT_COLOUR_D"}%s{"#ACTION_COLOUR_D"}]-", iID, strNames[iID], strRANames[remote_clientid]);
					
				SendClientMessageToAll(ACTION_COLOUR, gQuery);
				Kick(iID);
			}
		}
	}
	else if(strcmp(splitdata[0], "ban", true) == 0)
	{
		if(iLevel[remote_clientid] < BAN_LEVEL) sendToClient(remote_clientid, "apop:You are not a high enough level!");
		else
		{			
			new
				banTime,
				banID,
				banReason[50];
				
			ra_sscanf(data, "p:siis", splitdata[0], banID, banTime, banReason);

			banPlayer(banID, banReason, banTime, remote_clientid);
		}	
	}
	else if(strcmp(splitdata[0], "skin", true) == 0)
	{
		if(iLevel[remote_clientid] < SKIN_LEVEL) sendToClient(remote_clientid, "spop:You are not a high enough level!");
		else
		{
			new iID, skin;
		
			ra_sscanf(data, "p:sui", splitdata[0], iID, skin);
			
			if(iID == INVALID_PLAYER_ID) sendToClient(remote_clientid, "spop:The player you specified was not found!");
			else
			{
				if(skin > 299) sendToClient(remote_clientid, "spop:Invalid skin specified!");
				else SetPlayerSkin(iID, skin), sendToClient(remote_clientid, "spop:The players skin has been changed");
			}
		}
	}
	else if(strcmp(splitdata[0], "health", true) == 0)
	{
		if(iLevel[remote_clientid] < HEALTH_LEVEL) sendToClient(remote_clientid, "spop:You are not a high enough level!");
		else
		{
			new iID, Float: health;
		
			ra_sscanf(data, "p:suf", splitdata[0], iID, health);
			
			if(iID == INVALID_PLAYER_ID) sendToClient(remote_clientid, "spop:The player you specified was not found!");
			else
			{
				SetPlayerHealth(iID, health);	
				sendToClient(remote_clientid, "spop:The players health has been changed");
			}
		}
	}
	else if(strcmp(splitdata[0], "armour", true) == 0)
	{
		if(iLevel[remote_clientid] < ARMOUR_LEVEL) sendToClient(remote_clientid, "spop:You are not a high enough level!");
		else
		{
			new iID, Float: armour;
		
			ra_sscanf(data, "p:suf", splitdata[0], iID, armour);
			
			if(iID == INVALID_PLAYER_ID) sendToClient(remote_clientid, "spop:The player you specified was not found!");
			else
			{
				SetPlayerArmour(iID, armour);
				sendToClient(remote_clientid, "spop:The players armour has been changed");
			}
		}
	}
	else if(strcmp(splitdata[0], "score", true) == 0)
	{
		if(iLevel[remote_clientid] < SCORE_LEVEL) sendToClient(remote_clientid, "spop:You are not a high enough level!");
		else
		{
			new iID, score;
		
			ra_sscanf(data, "p:sui", splitdata[0], iID, score);
			
			if(iID == INVALID_PLAYER_ID) sendToClient(remote_clientid, "spop:The player you specified was not found!");
			else
			{
				SetPlayerScore(iID, score);
				sendToClient(remote_clientid, "spop:The players score has been changed");
			}
		}
	}
	else if(strcmp(splitdata[0], "weapon", true) == 0)
	{
		if(iLevel[remote_clientid] < WEAPON_LEVEL) sendToClient(remote_clientid, "spop:You are not a high enough level!");
		else
		{
			new iID, weapon;
		
			ra_sscanf(data, "p:sui", splitdata[0], iID, weapon);
			
			if(iID == INVALID_PLAYER_ID) sendToClient(remote_clientid, "spop:The player you specified was not found!");
			else
			{
				GivePlayerWeapon(iID, weapon, 999999);
				sendToClient(remote_clientid, "spop:The players weapon has been changed");
			}
		}
	}
	else if(strcmp(splitdata[0], "interior", true) == 0)
	{
		if(iLevel[remote_clientid] < INTERIOR_LEVEL) sendToClient(remote_clientid, "spop:You are not a high enough level!");
		else
		{
			new iID, interior;
		
			ra_sscanf(data, "p:sui", splitdata[0], iID, interior);
			
			if(iID == INVALID_PLAYER_ID) sendToClient(remote_clientid, "spop:The player you specified was not found!");
			else
			{
				SetPlayerInterior(iID, interior);
				sendToClient(remote_clientid, "spop:The players interior has been changed");
			}
		}
	}
	else if(strcmp(splitdata[0], "world", true) == 0)
	{
		if(iLevel[remote_clientid] < WORLD_LEVEL) sendToClient(remote_clientid, "spop:You are not a high enough level!");
		else
		{
			new iID, world;
		
			ra_sscanf(data, "p:sui", splitdata[0], iID, world);
			
			if(iID == INVALID_PLAYER_ID) sendToClient(remote_clientid, "spop:The player you specified was not found!");
			else
			{
				SetPlayerVirtualWorld(iID, world);
				sendToClient(remote_clientid, "spop:The players world has been changed");
			}
		}
	}
	else if(strcmp(splitdata[0], "vhealth", true) == 0)
	{
		if(iLevel[remote_clientid] < VHEALTH_LEVEL) sendToClient(remote_clientid, "spop:You are not a high enough level!");
		else
		{
			new iID, Float: vhealth;
		
			ra_sscanf(data, "p:suf", splitdata[0], iID, vhealth);
			
			if(iID == INVALID_PLAYER_ID) sendToClient(remote_clientid, "spop:The player you specified was not found!");
			else
			{
				SetVehicleHealth(GetPlayerVehicleID(iID), vhealth);
				sendToClient(remote_clientid, "spop:The players vehicle health has been changed");
			}
		}
	}
	else if(strcmp(splitdata[0], "alist", true) == 0)
	{
		if(iLevel[remote_clientid] < ADMIN_MANAGE) sendToClient(remote_clientid, "apop:You are not a high enough level!");
		else
		{
			sendAdminListToClient(remote_clientid);
		}
	}
	else if(strcmp(splitdata[0], "aset", true) == 0)
	{
		if(iLevel[remote_clientid] < ADMIN_MANAGE) sendToClient(remote_clientid, "apop:You are not a high enough level!");
		else
		{
			new 
				tmpName[24],
				tmpLevel;
				
			ra_sscanf(splitdata[2], "p:si", tmpName, tmpLevel);
			
			setNewAdminInfo(remote_clientid, strval(splitdata[1]), tmpName, tmpLevel);
		}
	}
	else if(strcmp(splitdata[0], "apass", true) == 0)
	{
		if(iLevel[remote_clientid] < ADMIN_MANAGE) sendToClient(remote_clientid, "apop:You are not a high enough level!");
		else
		{			
			setNewAdminPass(remote_clientid, strval(splitdata[1]), splitdata[2]);
		}
	}
	else if(strcmp(splitdata[0], "anew", true) == 0)
	{
		if(iLevel[remote_clientid] < ADMIN_MANAGE) sendToClient(remote_clientid, "apop:You are not a high enough level!");
		else
		{			
			new 
				tmpName[24], 
				tmpLevel;
			
			ra_sscanf(data, "p:ssis", splitdata[0], splitdata[1], tmpLevel, tmpName);
			
			if(strfind(tmpName, ":") != -1) sendToClient(remote_clientid, "apop:Well now, you've done some hacking haven't you? Server authenticated my friend.");
			else createNewAdminAccount(remote_clientid, splitdata[1], tmpLevel, tmpName);
		}
	}
	else if(strcmp(splitdata[0], "adel", true) == 0)
	{
		if(iLevel[remote_clientid] < ADMIN_MANAGE) sendToClient(remote_clientid, "apop:You are not a high enough level!");
		else
		{			
			deleteAdminAccount(remote_clientid, strval(splitdata[1]));
		}
	}
	else if(strcmp(splitdata[0], "blist", true) == 0)
	{
		if(iLevel[remote_clientid] < BAN_MANAGE) sendToClient(remote_clientid, "apop:You are not a high enough level!");
		else
		{			
			if(!strlen(splitdata[1])) return 1;
			
			sendBanListToClient(remote_clientid, strval(splitdata[1]), splitdata[2]);
		}	
	}
	else if(strcmp(splitdata[0], "delb", true) == 0)
	{
		if(iLevel[remote_clientid] < BAN_MANAGE) sendToClient(remote_clientid, "apop:You are not a high enough level!");
		else
		{			
			if(!strlen(splitdata[1])) return 1;
			deleteBan(remote_clientid, strval(splitdata[1]));
		}	
	}
	else if(strcmp(splitdata[0], "setb", true) == 0)
	{
		if(iLevel[remote_clientid] < BAN_MANAGE) sendToClient(remote_clientid, "apop:You are not a high enough level!");
		else
		{			
			new
				banID,
				banName[MAX_PLAYER_NAME],
				banIP[16],
				banAdmin[MAX_PLAYER_NAME],
				banMinutes,
				banStamp,
				banReason[50];
				
			ra_sscanf(data, "p:sisssiis", splitdata[0], banID, banName, banIP, banAdmin, banMinutes, banStamp, banReason);
			
			if(!strlen(banName) || !strlen(banName) || !strlen(banIP) || !strlen(banAdmin) || !strlen(banReason)) sendToClient(remote_clientid, "apop:You've probably done something wrong on purpose.");
			else updateBan(remote_clientid, banID, banName, banIP, banAdmin, banMinutes, banStamp, banReason);
		}		
	}
	return 1;
}

stock isBanned(playerid)
{
	format(gQuery, MAX_QUERY_LENGTH, "SELECT user_banned, ban_reason, ban_time, (ban_timestamp + (ban_time * 60) - strftime('%%s', 'now')) as banTimeLeft, strftime('%%d-%%m-%%Y %%H:%%M', datetime(ban_timestamp + (ban_time * 60), 'unixepoch')) as banExpired, strftime('%%d-%%m-%%Y %%H:%%M', datetime(ban_timestamp, 'unixepoch')) as bannedFrom, user_banner FROM `bans` WHERE user_banned_ip = '%s' AND (banTimeLeft > 0 OR ban_time = 0);", strIP[playerid]);
	
	gResult = db_query(gDB, gQuery);
	
	if(db_num_rows(gResult) > 0)
	{
		isbanned[playerid] = true;
	
		new
			banName[MAX_PLAYER_NAME],
			banReason[50],
			banTime[10],
			banTimeExpire[20],
			banFrom[20],
			banAdmin[MAX_PLAYER_NAME];
	
		db_get_field(gResult, 0, banName, MAX_PLAYER_NAME);
		db_get_field(gResult, 1, banReason, 50);
		db_get_field(gResult, 2, banTime, 10);
		db_get_field(gResult, 4, banTimeExpire, 20);
		db_get_field(gResult, 5, banFrom, 20);
		db_get_field(gResult, 6, banAdmin, 20);
		
		if(strval(banTime) == 0) format(banTimeExpire, sizeof(banTimeExpire), "Never");
		
		format(gQuery, sizeof(gQuery), "{FFFFFF}Sorry {FF6600}%s{FFFFFF}, you are banned!\n\n{1975FF}Banned as: {FF6600}%s\n{1975FF}Reason: {FF6600}%s\n{1975FF}Banned by: {FF6600}%s\n{1975FF}Banned on: {FF6600}%s\n{1975FF}Expires: {FF6600}%s", strNames[playerid], banName, banReason, banAdmin, banFrom, banTimeExpire);
		
		ShowPlayerDialog(playerid, 9098, DIALOG_STYLE_MSGBOX, "You are banned!", gQuery, "Ok", "Cancel");
		
		SetTimerEx("kickPlayer", 2000, false, "i", playerid);
	}
	else return 0;
	
	db_free_result(gResult);
	return 1;
}

// Need to do this as there is some bug with kicking instantly on connection!
public kickPlayer(playerid)
{
	Kick(playerid);
	return 1;
}

stock banPlayer(id, reason[], time, clientid)
{
	format(gQuery, sizeof(gQuery), "INSERT INTO `"#BAN_TABLE"` (user_banned, user_banned_ip, user_banner, ban_reason, ban_time, ban_timestamp) VALUES ('%s', '%s', '%s', '%s', %i, strftime('%%s', 'now'))", strNames[id], strIP[id], strRANames[clientid], db_escape(reason), time);	
	db_free_result(db_query(gDB, gQuery));
	
	if(strlen(reason) > 0)
		format(gQuery, sizeof(gQuery), "-[{"#AFFECT_COLOUR_D"}(%d) %s{"#ACTION_COLOUR_D"} has been banned by remote admin {"#AFFECT_COLOUR_D"}%s {"#ACTION_COLOUR_D"}(Reason: %s)]-", id, strNames[id], strRANames[clientid], reason);
	else
		format(gQuery, sizeof(gQuery), "-[{"#AFFECT_COLOUR_D"}(%d) %s{"#ACTION_COLOUR_D"} has been banned by remote admin {"#AFFECT_COLOUR_D"}%s{"#ACTION_COLOUR_D"}]-", id, strNames[id], strRANames[clientid]);
		
	SendClientMessageToAll(ACTION_COLOUR, gQuery);
	Kick(id);
}

stock updateBan(clientid, banID, banName[], banIP[], banAdmin[], banMinutes, banStamp, banReason[])
{
	format(gQuery, sizeof(gQuery), "UPDATE `"#BAN_TABLE"` SET user_banned = '%s', user_banned_ip = '%s', user_banner = '%s', ban_time = %i, ban_timestamp = %i, ban_reason = '%s' WHERE ID = %i", db_escape(banName), db_escape(banIP), db_escape(banAdmin), banMinutes, banStamp, db_escape(banReason), banID);
	db_free_result(db_query(gDB, gQuery));
	
	format(gQuery, sizeof(gQuery), "apop:Ban updated successfully!:%i", banID);
	sendToClient(clientid, gQuery);
}

stock deleteBan(clientid, banid)
{
	format(gQuery, sizeof(gQuery), "DELETE FROM `"#BAN_TABLE"` WHERE ID = %i", banid);
	db_free_result(db_query(gDB, gQuery));
	
	format(gQuery, sizeof(gQuery), "apop:Ban deleted successfully!:%i", banid);
	sendToClient(clientid, gQuery);
}

stock deleteAdminAccount(clientid, adminid)
{
	format(gQuery, sizeof(gQuery), "DELETE FROM `"#ADMIN_TABLE"` WHERE ID = %i", adminid);
	db_free_result(db_query(gDB, gQuery));
	
	sendToClient(clientid, "apop:Administrator deleted successfully!");
}

stock createNewAdminAccount(clientid, hash[], level, name[])
{
	format(gQuery, sizeof(gQuery), "INSERT INTO `"#ADMIN_TABLE"` (user_name, user_password, user_level) VALUES ('%s', '%s', '%i')", db_escape(name), db_escape(hash), level);
	db_free_result(db_query(gDB, gQuery));
	
	
	format(gQuery, sizeof(gQuery), "SELECT ID FROM `"#ADMIN_TABLE"` WHERE user_name = '%s' ORDER BY ID DESC", db_escape(name));
	gResult = db_query(gDB, gQuery);
	
	new tmpStr[2];
	
	db_get_field(gResult, 0, tmpStr, 2);
	
	db_free_result(gResult);
	
	format(gQuery, sizeof(gQuery), "anew:%i:%i:%s", strval(tmpStr), level, name);
	
	sendToClient(clientid, gQuery);
}

stock setNewAdminPass(clientid, adminid, pass[])
{
	format(gQuery, sizeof(gQuery), "UPDATE `"#ADMIN_TABLE"` SET user_password = '%s' WHERE ID = %i", db_escape(pass), adminid);
	db_free_result(db_query(gDB, gQuery));
	
	sendToClient(clientid, "apop:Set password successfully!");
}

stock setNewAdminInfo(clientid, adminid, name[], level)
{
	format(gQuery, sizeof(gQuery), "UPDATE `"#ADMIN_TABLE"` SET user_name = '%s', user_level = %i WHERE ID = %i", db_escape(name), level, adminid);
	db_free_result(db_query(gDB, gQuery));
	
	format(gQuery, sizeof(gQuery), "apop:Modified user successfully:%i", adminid);
	sendToClient(clientid, gQuery);
}

stock sendPlayerListToClient(clientid)
{
	strPlayerlist = "log:";
		
	for(new i; i < MAX_PLAYERS; i++)
		if(IsPlayerConnected(i)) 
		{
			format(gQuery, sizeof(gQuery), "%d:%s:", i, strNames[i]);
			strcat(strPlayerlist, gQuery);
		}
	socket_sendto_remote_client(gSocket, clientid, strPlayerlist);
}

stock sendAdminListToClient(clientid)
{
	gResult = db_query(gDB, "SELECT ID, user_name, user_level FROM `"#ADMIN_TABLE"`");
	
	new 
		tmpID[4], 
		tmpName[MAX_PLAYER_NAME],
		tmpLevel[2];
		
	strPlayerlist = "alist";
	
	do
	{
		db_get_field(gResult, 0, tmpID, 4);
		db_get_field(gResult, 1, tmpName, MAX_PLAYER_NAME);
		db_get_field(gResult, 2, tmpLevel, 2);
		
		format(gQuery, sizeof(gQuery), ":%i:%s:%i", strval(tmpID), tmpName, strval(tmpLevel));
		strcat(strPlayerlist, gQuery);
	}
	while(db_next_row(gResult));
	
	db_free_result(gResult);
	
	sendToClient(clientid, strPlayerlist);
}

stock sendBanListToClient(clientid, index, filter[] = "")
{
	format(gQuery, sizeof(gQuery), "SELECT * FROM `"#BAN_TABLE"` WHERE user_banned LIKE '%%%s%%' OR user_banned_ip LIKE '%%%s%%' OR user_banner LIKE '%%%s%%' OR ban_reason LIKE '%%%s%%' ORDER BY ban_timestamp DESC LIMIT %i, 20", filter, filter, filter, filter, index * 20);
	
	gResult = db_query(gDB, gQuery);
	
	if(db_num_rows(gResult) == 0) sendToClient(clientid, "apop:Sorry, no results found!");
	else
	{
	
		new 
			tmpID[4], 
			tmpName[MAX_PLAYER_NAME],
			tmpIP[16],
			tmpAdmin[MAX_PLAYER_NAME],
			tmpReason[40],
			tmpStamp[20],
			tmpTime[10];
			
		strPlayerlist = "blist";
			
		do
		{
			db_get_field(gResult, 0, tmpID, 4);
			db_get_field(gResult, 1, tmpName, MAX_PLAYER_NAME);
			db_get_field(gResult, 2, tmpIP, 16);
			db_get_field(gResult, 3, tmpAdmin, MAX_PLAYER_NAME);
			db_get_field(gResult, 4, tmpReason, 40);
			db_get_field(gResult, 5, tmpStamp, 20);
			db_get_field(gResult, 6, tmpTime, 10);

			format(gQuery, sizeof(gQuery), ":%i:%s:%s:%s:%s:%i:%i", strval(tmpID), tmpName, tmpIP, tmpAdmin, tmpReason, strval(tmpTime), strval(tmpStamp));
			strcat(strPlayerlist, gQuery);
		}
		while(db_next_row(gResult));
		
		db_free_result(gResult);

		sendToClient(clientid, strPlayerlist);
	}
}

stock sendPermissionsToClient(clientid)
{
	format(gQuery, sizeof(gQuery), "perm:%i:%i:%i:%i:%i:%i:%i:%i:%i:%i:%i:%i:%i:%i", iLevel[clientid], KICK_LEVEL, BAN_LEVEL, INFO_LEVEL, SKIN_LEVEL, HEALTH_LEVEL, ARMOUR_LEVEL, WEAPON_LEVEL, SCORE_LEVEL, INTERIOR_LEVEL, WORLD_LEVEL, VHEALTH_LEVEL, ADMIN_MANAGE, BAN_MANAGE);
	
	sendToClient(clientid, gQuery);
}

stock sendToClients(data[])
{
	for(new i; i < MAX_CONNECTIONS; i++) if(bLogged[i]) socket_sendto_remote_client(gSocket, i, data);
}

stock sendToClient(clientid, data[])
{
	socket_sendto_remote_client(gSocket, clientid, data);
}

stock sendToAllButClient(clientid, data[])
{
	for(new i; i < MAX_CONNECTIONS; i++) if(bLogged[i] && i != clientid) socket_sendto_remote_client(gSocket, i, data);
}

stock checkUserCredentials(clientid, Username[], Password[])
{
	format(gQuery, sizeof(gQuery), "SELECT user_level FROM `"#ADMIN_TABLE"` WHERE user_name = '%s' AND user_password = '%s'", db_escape(Username), db_escape(Password));
	gResult = db_query(gDB, gQuery);
	
	if(db_num_rows(gResult) != 0)
	{
		new tmpresult[3];
	
		db_get_field(gResult, 0, tmpresult, 3);
		
		db_free_result(gResult);
		
		iLevel[clientid] = strval(tmpresult);
		
		strmid(strRANames[clientid], Username, 0, strlen(Username));
		return iLevel[clientid];
	}
	return -1;
}

stock split(const strsrc[], strdest[][], delimiter = '|')
{
	new i, li, aNum, len, srclen = strlen(strsrc);
	while(i <= srclen)
	{
		if (strsrc[i] == delimiter || i == srclen)
		{
			len = strmid(strdest[aNum], strsrc, li, i, 128);
			strdest[aNum][len] = 0;
			li = i + 1;
			aNum++;
		}
		i++;
	}
}

public OnPlayerConnect(playerid)
{
	isbanned[playerid] = false;

	GetPlayerName(playerid, strNames[playerid], MAX_PLAYER_NAME);
	GetPlayerIp(playerid, strIP[playerid], 16);
	
	player_count++;
	
	if(isBanned(playerid)) return 1;
	
	format(gQuery, sizeof(gQuery), "con:%d:%s", playerid, strNames[playerid]);
	sendToClients(gQuery);
	return 1;
}

public OnPlayerDisconnect(playerid, reason)
{
	player_count--;

	if(isbanned[playerid]) return 1;
	
	format(gQuery, sizeof(gQuery), "dcon:%d:%s:%d", playerid, strNames[playerid], reason);	
	sendToClients(gQuery);
	return 1;
}

public OnPlayerText(playerid, text[])
{
	format(gQuery, sizeof(gQuery), "msg:%d:%s:%s", playerid, strNames[playerid], text);	
	sendToClients(gQuery);
	return 1;
}

public onSocketRemoteDisconnect(Socket:id, remote_clientid)
{
	bLogged[remote_clientid] = false;
	return 1;
}

// Thanks to the author of this on the SA-MP Wiki
stock db_escape(text[])
{
	new
		ret[24 * 2],
		ch,
		i,
		j;
	while ((ch = text[i++]) && j < sizeof (ret))
	{
		if (ch == '\'')
		{
			if (j < sizeof (ret) - 2)
			{
				ret[j++] = '\'';
				ret[j++] = '\'';
			}
		}
		else if (j < sizeof (ret))
		{
			ret[j++] = ch;
		}
		else
		{
			j++;
		}
	}
	ret[sizeof (ret) - 1] = '\0';
	return ret;
}

//---------------------------------
// sscanf by Alex "Y_Less" Cole
// http://www.y-less.com
//---------------------------------
stock ra_sscanf(string[], format[], {Float,_}:...)
{
	#if defined isnull
		if (isnull(string))
	#else
		if (string[0] == 0 || (string[0] == 1 && string[1] == 0))
	#endif
		{
			return format[0];
		}
	#pragma tabsize 4
	new
		formatPos = 0,
		stringPos = 0,
		paramPos = 2,
		paramCount = numargs(),
		delim = ' ';
	while (string[stringPos] && string[stringPos] <= ' ')
	{
		stringPos++;
	}
	while (paramPos < paramCount && string[stringPos])
	{
		switch (format[formatPos++])
		{
			case '\0':
			{
				return 0;
			}
			case 'i', 'd':
			{
				new
					neg = 1,
					num = 0,
					ch = string[stringPos];
				if (ch == '-')
				{
					neg = -1;
					ch = string[++stringPos];
				}
				do
				{
					stringPos++;
					if ('0' <= ch <= '9')
					{
						num = (num * 10) + (ch - '0');
					}
					else
					{
						return -1;
					}
				}
				while ((ch = string[stringPos]) > ' ' && ch != delim);
				setarg(paramPos, 0, num * neg);
			}
			case 'h', 'x':
			{
				new
					num = 0,
					ch = string[stringPos];
				do
				{
					stringPos++;
					switch (ch)
					{
						case 'x', 'X':
						{
							num = 0;
							continue;
						}
						case '0' .. '9':
						{
							num = (num << 4) | (ch - '0');
						}
						case 'a' .. 'f':
						{
							num = (num << 4) | (ch - ('a' - 10));
						}
						case 'A' .. 'F':
						{
							num = (num << 4) | (ch - ('A' - 10));
						}
						default:
						{
							return -1;
						}
					}
				}
				while ((ch = string[stringPos]) > ' ' && ch != delim);
				setarg(paramPos, 0, num);
			}
			case 'c':
			{
				setarg(paramPos, 0, string[stringPos++]);
			}
			case 'f':
			{
 
				new changestr[16], changepos = 0, strpos = stringPos;     
				while(changepos < 16 && string[strpos] && string[strpos] != delim)
				{
					changestr[changepos++] = string[strpos++];
    				} 
				changestr[changepos] = '\0'; 
				setarg(paramPos,0,_:floatstr(changestr)); 
			} 
			case 'p':
			{
				delim = format[formatPos++];
				continue;
			}
			case '\'':
			{
				new
					end = formatPos - 1,
					ch;
				while ((ch = format[++end]) && ch != '\'') {}
				if (!ch)
				{
					return -1;
				}
				format[end] = '\0';
				if ((ch = strfind(string, format[formatPos], false, stringPos)) == -1)
				{
					if (format[end + 1])
					{
						return -1;
					}
					return 0;
				}
				format[end] = '\'';
				stringPos = ch + (end - formatPos);
				formatPos = end + 1;
			}
			case 'u':
			{
				new
					end = stringPos - 1,
					id = 0,
					bool:num = true,
					ch;
				while ((ch = string[++end]) && ch != delim)
				{
					if (num)
					{
						if ('0' <= ch <= '9')
						{
							id = (id * 10) + (ch - '0');
						}
						else
						{
							num = false;
						}
					}
				}
				if (num && IsPlayerConnected(id))
				{
					setarg(paramPos, 0, id);
				}
				else
				{
					#if !defined foreach
						#define foreach(%1,%2) for (new %2 = 0; %2 < MAX_PLAYERS; %2++) if (IsPlayerConnected(%2))
						#define __SSCANF_FOREACH__
					#endif
					string[end] = '\0';
					num = false;
					new
						name[MAX_PLAYER_NAME];
					id = end - stringPos;
					foreach (Player, playerid)
					{
						GetPlayerName(playerid, name, sizeof (name));
						if (!strcmp(name, string[stringPos], true, id))
						{
							setarg(paramPos, 0, playerid);
							num = true;
							break;
						}
					}
					if (!num)
					{
						setarg(paramPos, 0, INVALID_PLAYER_ID);
					}
					string[end] = ch;
					#if defined __SSCANF_FOREACH__
						#undef foreach
						#undef __SSCANF_FOREACH__
					#endif
				}
				stringPos = end;
			}
			case 's', 'z':
			{
				new
					i = 0,
					ch;
				if (format[formatPos])
				{
					while ((ch = string[stringPos++]) && ch != delim)
					{
						setarg(paramPos, i++, ch);
					}
					if (!i)
					{
						return -1;
					}
				}
				else
				{
					while ((ch = string[stringPos++]))
					{
						setarg(paramPos, i++, ch);
					}
				}
				stringPos--;
				setarg(paramPos, i, '\0');
			}
			default:
			{
				continue;
			}
		}
		while (string[stringPos] && string[stringPos] != delim && string[stringPos] > ' ')
		{
			stringPos++;
		}
		while (string[stringPos] && (string[stringPos] == delim || string[stringPos] <= ' '))
		{
			stringPos++;
		}
		paramPos++;
	}
	do
	{
		if ((delim = format[formatPos++]) > ' ')
		{
			if (delim == '\'')
			{
				while ((delim = format[formatPos++]) && delim != '\'') {}
			}
			else if (delim != 'z')
			{
				return delim;
			}
		}
	}
	while (delim > ' ');
	return 0;
}
