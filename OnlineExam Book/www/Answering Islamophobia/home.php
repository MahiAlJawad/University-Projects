<?php include 'inc/header.php'?>
<?php include 'Database/database.php' ?>
<?php include 'helpers/format.php'?>

<?php
$db= new database();
$userid= $_GET['userid'];

$query= "select * from post";
$result= $db->select($query);
$format= new format();

?>



<div class="navsection templete">
	<ul>
		<li><a id="active" href="home.php?userid=<?php echo $userid;?>">Home</a></li>
		<li><a href="profile.php?userid=<?php echo $userid;?>">Profile</a></li>
		<li><a href="about.php?userid=<?php echo $userid;?>">About</a></li>	
		<li><a href="compose.php?userid=<?php echo $userid; ?>">Compose</a></li>
		<?php
			if($userid== 1)
			{?>
				<li><a href="admin.php?userid=<?php echo $userid; ?>">Admin Panel</a></li>
			<?php }
		?>
	</ul>
</div>

<?php include 'inc/slider.php' ?>

	<div class="contentsection contemplete clear">
		<div class="maincontent clear">
			
			<?php if($result) { while($row= $result->fetch_assoc())
			{?>
			<div class="samepost clear">
				
				<h2><a href=""><?php echo $row['title']; ?></a></h2>
				<h4><?php echo $format->formatDate($row['date']); ?>, By <a href="#"><?php echo $row['author']; ?></a></h4>
				 <a href="#"><img src= "images/pic<?php echo $row['id'];?>.jpg" alt="post image"/></a>
				<p>
				 	<?php echo $format->textShortening($row['body']); ?>
				</p>
				
				<div class="readmore clear">
					<a href="post.php?id=<?php echo $row['id']?>&userid=<?php echo $userid;?>">Read More</a>
				</div>
			</div>
		<?php }} else{
			echo "No Post Found...";
		} ?>


		</div>
		<?php include 'inc/sidebar.php' ?>
		
	</div>

<?php include 'inc/footer.php'?>