<?php include 'inc/header.php' ?>
<?php include 'Database/database.php' ?>

<?php

$userid= $_GET['userid'];

?>

<div class="navsection templete">
	<ul>
		<li><a  href="home.php?userid=<?php echo $userid;?>">Home</a></li>
		<li><a href="profile.php?userid=<?php echo $userid;?>">Profile</a></li>
		<li><a id="active" href="about.php?userid=<?php echo $userid;?>">About</a></li>	
		<li><a href="compose.php?userid=<?php echo $userid; ?>">Compose</a></li>
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
				<h2>About us</h2>
	
				<p>.Some text will be go here. Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here. Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.</p>
				
				<p>About me..Some text will be go here. Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here. Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.</p>
				
				<p>About me..Some text will be go here. Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here. Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.Some text will be go here.</p>
			</div>

		</div>
		<?php include 'inc/sidebar.php' ?>
	</div>

<?php include 'inc/footer.php' ?>