<!DOCTYPE html>
<head>
<meta charset="utf-8">
<title>Sign Up</title>
    <link rel="stylesheet" type="text/css" href="css/stylelogin.css" media="screen" />
</head>
<body>
<?php include 'Database/database.php' ?>	


<div class="container">
	<section id="content">
		<form action="signup.php" method="post">
			<h1>Sign Up</h1>
			<div>
				<input type="text" placeholder="Enter Your Full Name" required="" name="name"/>
			</div>
			<div>
				<input type="text" placeholder="Enter an Username" required="" name="username"/>
			</div>
			<div>
				<input type="password" placeholder="Select a Password" required="" name="password"/>
			</div>
			
			<div>
				<input type="password" placeholder="Rewrite the Password" required="" name="rpassword"/>
			</div>
			<div>
				<input type="text" placeholder="Email, e.g ab@cd.com" required="" name="email"/>
			</div>
			<div>
				<input type="text" placeholder="Gender, e.g. male/female/others" required="" name="gender"/>
			</div>

			<div>
				<input type="text" placeholder="Enter Your Age" required="" name="age"/>
			</div>

			<div>
				<input type="text" placeholder="Religion" required="" name="religion"/>
			</div>
			<div>
				<input type="text" placeholder="Country" required="" name="country"/>
			</div>

			<div>
				<input type="submit" name= "signup" value="Sign Up" />
			</div>
		</form><!-- form -->
		<div class="button">
			<a href="#">Answering Islamophobia</a>
		</div><!-- button -->
	</section><!-- content -->
</div><!-- container -->

<?php

if(isset($_POST['signup']))
{
	$name= $_POST['name'];
	$username= $_POST['username'];
	$password= $_POST['password'];
	$rpassword= $_POST['rpassword'];
	$email= $_POST['email'];
	$gender= $_POST['gender'];
	$age= $_POST['age'];
	$religion= $_POST['religion'];
	$country= $_POST['country'];



	$db= new database();

	$query= "select * from user where username= '$username'";
	$result= $db->select($query);

	if($result)
	{
		echo "<p style= 'text-align: center; color: red; font-size: 19px; font-family: TImes New Roman'><b>The Username is already in use, please try another one.</b><p>";
	}
	else
	{
		if($password!= $rpassword)
		{
			echo "<p style= 'text-align: center; color: red; font-size: 19px; font-family: TImes New Roman'><b>Both the Passwords did not match. Please try again.</b><p>";
		}
		else
		{
			$query= "insert into user(name, username, password, email, gender, age, religion, country) values('$name', '$username', '$password', '$email', '$gender', '$age', '$religion', '$country')";
			$f= $db->dbinsert($query);

			if(!$f)
			{
				echo "<p style= 'text-align: center; color: red; font-size: 19px; font-family: TImes New Roman'><b>SORRY! ERROR 404! Try again later.</b><p>";
			}
			else
			{
				header("Location: index.php");
				exit();
			}
		}
	}

}
else
{
	echo "nothig foiund";
}

?>


</body>
</html>