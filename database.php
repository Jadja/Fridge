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