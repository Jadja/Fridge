<?php

$CONFIG['DB_USER'] = 'root';
$CONFIG['DB_PASS'] = 'root';
$CONFIG['DB_HOST'] = '127.0.0.1';
$CONFIG['DB_NAME'] = 'fifo db';

function GetDatabaseUser() {
	global $CONFIG;
	return $CONFIG['DB_USER'];
}

function GetDatabasePassword() {
	global $CONFIG;
	return $CONFIG['DB_PASS'];
}

function GetDatabaseName() {
	global $CONFIG;
	return $CONFIG['DB_NAME'];
}

function GetDatabaseHost() {
	global $CONFIG;
	return $CONFIG['DB_HOST'];
}
