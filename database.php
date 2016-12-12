<?php
require_once('config.php');

/*
	public function GetAllRowsInTable($TableName) {
		$Result = $this->connection->query("SELECT * FROM $TableName");
		if (!$Result || $Result->rowCount() == 0) {
			return false;
		}
		return $Result->fetchAll(PDO::FETCH_ASSOC);
	}

	public function GetLastRowsInTable($TableName, $Limit) {
		$Result = $this->connection->query("SELECT * FROM $TableName ORDER BY ID DESC LIMIT 0, $Limit");
		if (!$Result || $Result->rowCount() == 0) {
			return false;
		}
		return $Result->fetchAll(PDO::FETCH_ASSOC);
	}

	public function InsertRowIntoTable($TableName, $Values) {
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
		$this->connection->query($Query);
	}

	public function UpdateRowInTable($TableName, $Where, $SetValues) {
		$Query = "UPDATE $TableName SET ";
		foreach ($SetValues as $Name => $Value) {
			$Query .= "$Name = $Value,";
		}
		$Query = substr($Query, 0, -1) . " $Where";
		$this->connection->query($Query);
	}

	public function DeleteRowFromTable($TableName, $Where) {
		$this->connection->query("DELETE FROM $TableName $Where");
	}

	public function SelectByID($TableName, $ID) {
		return $this->SelectFirstFromTable($TableName, array('ID' => intval($ID)), '');
	}
*/

function console_log($data) {
	echo '<script>console.log(' . json_encode( $data ) . ')</script>';
}

class Database {
	private $_Connection;

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
		return $result->fetchAll(PDO::FETCH_ASSOC);
	}

	public function SelectFirstFromTable($tableName, $whereArray, $options) {
		$rows = $this->SelectAllFromTable($tableName, $whereArray, $options);
		if (!$rows) {
			return false;
		}
		return $rows[0];
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