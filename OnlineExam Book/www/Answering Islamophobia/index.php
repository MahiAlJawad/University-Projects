<!DOCTYPE html>
<head>
<meta charset="utf-8">
<title>Login</title>
    <link rel="stylesheet" type="text/css" href="css/stylelogin.css" media="screen" />
</head>
<body>
<?php include 'Database/database.php' ?>	


<div class="container">
	<section id="content">
		<form action="index.php" method="post">
			<h1>Login</h1>
			<div>
				<input type="text" placeholder="Username"  name="username"/>
			</div>
			<div>
				<input type="password" placeholder="Password"  name="password"/>
			</div>
			<div>
				<input type="submit" name="login" value="Login" />
				<input type="submit" name= "signup" value="Sign Up" />
			</div>
		</form><!-- form -->
		<div class="button">
			<a href="#">Answering Islamophobia</a>
		</div><!-- button -->
	</section><!-- content -->
</div><!-- container -->


<?php
$db= new database();
if(isset($_POST['login']))
{
	$username= $_POST['username'];
	$password= $_POST['password'];
	if($username== "" || $password== "")
	{
		echo "<p style= 'text-align: center; color: red; font-size: 19px; font-family: TImes New Roman'><b>Please fill up all the fields.</b><p>";
	}
	else
	{
		$query= "select * from user where username= '$username'";
		$result= $db->select($query);
		if($result)
		{
			$row= $result->fetch_assoc();
			$userid= $row['id'];
			
			$pass= $row['password'];

			if($pass!= $password)
			{
				echo "<p style= 'text-align: center; color: red; font-size: 19px; font-family: TImes New Roman'><b>Username of Password is incorrect.</b><p>";
			}
			else
			{
				header("Location: home.php?userid=".$userid);
				exit();
			}	
		}
		else
		{
			echo "<p  style= 'text-align: center; color: red; font-size: 19px; font-family: TImes New Roman'><b>Usename of Password is incorrect.</b><p>";
		}
	}
}
elseif (isset($_POST['signup'])) 
{
	header("Location: signup.php");
				exit();
}

?>


</body>
</html>