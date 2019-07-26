<?php include 'inc/header.php' ?>
<?php include 'Database/database.php' ?>
<?php
$userid= $_GET['userid'];
$db= new database();
$query= "select * from user where id='$userid'";
$result= $db->select($query);
$row= $result->fetch_assoc();

?>

<div class="navsection templete">
	<ul>
		<li><a  href="home.php?userid=<?php echo $userid;?>">Home</a></li>
		<li><a  href="profile.php?userid=<?php echo $userid;?>">Profile</a></li>
		<li><a href="about.php?userid=<?php echo $userid;?>">About</a></li>	
		<li><a id= "active" href="compose.php?userid=<?php echo $userid; ?>">Compose</a></li>
		<?php
			if($userid== 1)
			{?>
				<li><a href="admin.php?userid=<?php echo $userid; ?>">Admin Panel</a></li>
			<?php }
		?>
	</ul>
</div>




<div class="contentsection contemplete clear">
<div class="maincontent clear">
<div class="about">
			<h2>Write Post</h2>
			<form action="" method="post">
				<table>
				<tr>
					<td>Post title:</td>
					<td>
					<input type="text" name="title" placeholder="Write appropiate post title" required="1"/>
					</td>
				</tr>
				<tr>
					<td></td>
					<td>
					<textarea name= "body" placeholder="Write Your Post..."></textarea>
					</td>
				</tr>
				<tr>
					<td></td>
					<td>
					<input type="submit" name="submit" value="Submit"/>
					</td>
				</tr>
		</table>
	</form>				
</div>
<?php 
if(isset($_POST['submit']))
{
	echo "<p  style= 'text-align: center; color: red; font-size: 19px; font-family: TImes New Roman'><b><br><br><br>Your Post is Submitted for approval.</b><p>";
}

?>
</div>


		
	
<?php
$db= new database();

if(isset($_POST['submit']))
{

	
	$body= $_POST['body'];
	$author= $row['name'];
	$title= $_POST['title'];

	$query= "insert into pendingpost(title, body, author) values('$title', '$body', '$author')";
	$f= $db->dbinsert($query);
		
}


?>

<?php include 'inc/sidebar.php' ?>
</div>

<?php include 'inc/footer.php' ?>