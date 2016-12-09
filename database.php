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

function SelectFirstFromTable($TableName, $WhereArray, $Options) {
	$Rows = SelectAllFromTable($TableName, $WhereArray, $Options);
	if (!$Rows) {
		return false;
	}
	return $Rows[0];
}

function GetAllRowsInTable($TableName) {
	global $Database;
	$Result = $Database->query("SELECT * FROM $TableName");
	if (!$Result || $Result->rowCount() == 0) {
		return false;
	}
	return $Result->fetchAll(PDO::FETCH_ASSOC);
}

function GetLastRowsInTable($TableName, $Limit) {
	global $Database;
	$Result = $Database->query("SELECT * FROM $TableName ORDER BY ID DESC LIMIT 0, $Limit");
	if (!$Result || $Result->rowCount() == 0) {
		return false;
	}
	return $Result->fetchAll(PDO::FETCH_ASSOC);
}

function InsertRowIntoTable($TableName, $Values) {
	global $Database;
	if (!$Values) {
		return;
	}
	$Query = "INSERT INTO $TableName(";
	$ValuesString = '';
	foreach ($Values as $Field => $Value) {
		$Query .= $Field . ',';
		$ValuesString .= $Value . ',';
	}
	$Query = substr($Query, 0, -1);
	$ValuesString = substr($ValuesString, 0, -1);
	$Query .= ") VALUES($ValuesString)";
	$Database->query($Query);
}

function UpdateRowInTable($TableName, $Where, $SetValues) {
	global $Database;
	$Query = "UPDATE $TableName SET ";
	foreach ($SetValues as $Name => $Value) {
		$Query .= "$Name = $Value,";
	}
	$Query = substr($Query, 0, -1) . " $Where";
	$Database->query($Query);
}

function DeleteRowFromTable($TableName, $Where) {
	global $Database;
	$Database->query("DELETE FROM $TableName $Where");
}

function SelectByID($TableName, $ID) {
	return SelectFirstFromTable($TableName, array('ID' => intval($ID)), '');
}