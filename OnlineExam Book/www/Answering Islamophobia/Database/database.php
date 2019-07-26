<?php

include 'config.php';


class database
{
	public $host= db_host;
	public $user= db_user;
	public $pass= db_pass;
	public $dbname= db_name;


	public $link;
	public $error;

	public function __construct()
	{
		$this->connectdb();
	}
	private function connectdb()
	{
		$this->link = new mysqli($this->host, $this->user, $this->pass, $this->dbname);
		if(!$this->link)
		{
			$this->error ="Connection fail".$this->link->connect_error;
			return false;
		}
	}


	public function select($query)
	{
		$result = $this->link->query($query) or die($this->link->error.__LINE__);
		if($result->num_rows > 0)
		{
			return $result;
		} else
		{
			return false;
		}
	}


	public function dbinsert($query)
	{
		$insert_row = $this->link->query($query) or die($this->link->error.__LINE__);
		if($insert_row)
		{
			//header("Location: index.php");
			return true;
		} 
		else 
		{
			return false;
			//die("Error :(".$this->link->errno.")".$this->link->error);
		}
  	}

  	public function dbupdate($query)
  	{
		$update_row = $this->link->query($query) or die($this->link->error.__LINE__);
		if($update_row)
		{
			return true;

			//header("Location: index.php?msg=".urlencode('Data Updated successfully.'));
			//exit();
		} 
		else 
		{
			return false;
			//die("Error :(".$this->link->errno.")".$this->link->error);
		}
    }
}


?>