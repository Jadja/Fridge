<?php
require_once('config.php');

/*
	public function GetLastRowsInTable($TableName, $Limit) {
		$Result = $this->connection->query("SELECT * FROM $TableName ORDER BY ID DESC LIMIT 0, $Limit");
		if (!$Result || $Result->rowCount() == 0) {
			return false;
		}
		return $Result->fetchAll(PDO::FETCH_ASSOC);
	}

*/

function console_log($data) {
	echo '<script>console.log(' . json_encode($data) . ')</script>';
}

class Database {
	private $_Connection;

	//insert doesn't work yet :/
	public function InsertRowIntoTable($tableName, $values) {
		if (!$values) {
			return;
		}
		$sql = "INSERT INTO $tableName(";
		$valuesString = '';
		foreach ($values as $field => $value) {
			$sql .= $field . ',';
			$valuesString .= $value . ',';
		}
		$sql = substr($sql, 0, -1);
		$valuesString = substr($valuesString, 0, -1);
		$sql .= ") VALUES($valuesString)";
		$this->_Connection->query($sql);
	}

	public function SelectAllFromTable($tableName, $whereArray, $options) {
		$where = '';
		if ($whereArray) {
			$where = 'WHERE ';
			foreach ($whereArray as $Field => $Value) {
				$where .= $Field . ' = ' . $Value . ' AND ';
			}
			$where = substr($where, 0, -4);
		}
		$result = $this->_Connection->query("SELECT * FROM $tableName $where $options");
		if (!$result || $result->rowCount() == 0) {
			return false;
		}
		return $result->fetchAll(PDO::FETCH_OBJ);
	}

	public function SelectFirstFromTable($tableName, $whereArray, $options) {
		$rows = $this->SelectAllFromTable($tableName, $whereArray, $options);
		if (!$rows) {
			return false;
		}
		return $rows[0];
	}

	public function SelectByID($tableName, $id) {
		return $this->SelectFirstFromTable($tableName, array('ID' => intval($id)), '');
	}

	public function UpdateRowInTable($tableName, $where, $setValues) {
		$Query = "UPDATE $tableName SET ";
		foreach ($setValues as $name => $value) {
			$Query .= "$name = $value,";
		}
		$Query = substr($Query, 0, -1) . " $where";
		$this->_Connection->query($Query);
	}

	public function DeleteRowFromTable($tableName, $where) {
		$this->_Connection->query("DELETE FROM $tableName $where");
	}
	
	public function __construct() {
		try {
			$this->_Connection = new PDO('mysql:host=' . GetDatabaseHost() . ';dbname=' . GetDatabaseName() . ';charset=utf8', GetDatabaseUser(), GetDatabasePassword());
			$this->_Connection->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
		} catch (PDOException $e) {
			$this->_Connection = false;
		}
	}
}

$db = false;
if (!$db) {
	$db = new Database();
}
console_log($db);