<?php
require_once('config.php');

function CreateDatabaseConnection() {
	try {
		$Pdo = new PDO('mysql:host=' . GetDatabaseHost() . ';dbname=' . GetDatabaseName() . ';charset=utf8', GetDatabaseUser(), GetDatabasePassword());
	} catch (PDOException $e) {
		return false;
	}
	return $Pdo;
}

if(!isset($Database)) {
	$Database = CreateDatabaseConnection();
}

function SelectAllFromTable($TableName, $WhereArray, $Options) {
	global $Database;
	$Where = '';
	if ($WhereArray) {
		$Where = 'WHERE ';
		foreach($WhereArray as $Field => $Value) {
			$Where .= $Field . ' = ' . $Value . ' AND ';
		}
		$Where = substr($Where, 0, -4);
	}
	$Result = $Databse->query("SELECT * FROM $TableName $Where $Options");
	if (!$Result || $Result->rowCount() == 0) {
		return false;
	}
	return $Result->fetchAll(PDO::FETCH_ASSOC);
}