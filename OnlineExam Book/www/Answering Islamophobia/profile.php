<?php include 'inc/header.php' ?>
<?php include 'Database/database.php' ?>
<?php
$userid= $_GET['userid'];
$db= new database();
$query= "select * from user where id='$userid'";
$result= $db->select($query);
$row= $result->fetch_assoc();

if($row['no_of_test']== 0) $rating= 0;
else $rating= ($row['total_marks']/$row['no_of_test']);

$query= "update user set rating= '$rating' where id= '$userid'";
$db->dbupdate($query);

?>

<div class="navsection templete">
	<ul>
		<li><a  href="home.php?userid=<?php echo $userid;?>">Home</a></li>
		<li><a id="active" href="profile.php?userid=<?php echo $userid;?>">Profile</a></li>
		<li><a href="about.php?userid=<?php echo $userid;?>">About</a></li>	
		<li><a href="compose.php?userid=<?php echo $userid; ?>">Compose</a></li>
		<?php
			if($userid== 1)
			{?>
				<li><a href="compose.php?userid=<?php echo $userid; ?>">Admin Panel</a></li>
			<?php }
		?>
	</ul>
</div>




<div class="contentsection contemplete clear">
		<div class="maincontent clear">
			<div class="about">
				<h2 style="color: red"><?php echo $row['name'] ?></h2>			
 			</div>
 			

		</div>
		<div class= "maincontent">
			<img src="images/propic.jpg">
		</div>
		<div class= "maincontent">
			
			<br>
			<br>
			<br>
 				<table style="font-size: 19px; font-family: Times New Roman;">
				<tr>
					<td><b>Username</b></td>
					<td>: <?php echo $row['username'] ?></td>
				</tr>
				<tr>
					<td><b>Gender</b></td>
					<td>: <?php echo $row['gender'] ?></td>
				</tr>
				<tr>
					<td><b>Age</b></td>
					<td>: <?php echo $row['age'] ?></td>
				</tr>
				<tr>
					<td><b>Religion</b></td>
					<td>: <?php echo $row['religion'] ?></td>
				</tr>
				<tr>
					<td><b>Country</b></td>
					<td>: <?php echo $row['country'] ?></td>
				</tr>
				<tr>
					<td><b>Email</b></td>
					<td>:<?php echo $row['email'] ?></td>
				</tr>
				<tr>
					<td><b style="color: red">Rating</b></td>
					<td>: <?php echo $rating ?>%</td>
				</tr>
				
				</table>
 			</div>
		

		<?php include 'inc/sidebar.php' ?>
</div>

<?php include 'inc/footer.php' ?>