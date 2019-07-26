<?php include 'inc/header.php' ?>
<?php include 'Database/database.php' ?>
<?php include 'helpers/format.php'?>

<?php
$userid= $_GET['userid'];
$db= new database();
$postid= $_GET['id'];

$query= "select * from pendingpost where id= '$postid'";
$result= $db->select($query);
$format= new format();

 ?>

<div class="navsection templete">
	<ul>
		<li><a href="home.php?userid=<?php echo $userid;?>">Home</a></li>
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


	<div class="contentsection contemplete clear">
		<div class="maincontent clear">
			<div class="about">
				<?php if($result){ while($row= $result->fetch_assoc()){?>
				<h2><?php echo $row['title'] ?></h2>
				<h4><?php echo $format->formatDate($row['date']); ?>, By <?php echo $row['author']; ?></h4>
				<img src="images/pic<?php echo $postid;?>.jpg" alt="MyImage"/>
				<p><?php echo $row['body']; ?></p>

			<?php }}
			else{
				echo "Post is not Valid.\n";
			} ?>
				
			
			</div>

		</div>

		<div class="readmore clear">
					<a href="approve.php?id=<?php echo $postid?>&userid=<?php echo $userid;?>&msg=1">Approve</a>
					<br>
					<a href="approve.php?id=<?php echo $postid?>&userid=<?php echo $userid;?>&msg=2">Reject</a>
					<br>
					<br>
					<br>
		</div>
		
		<?php
			$msg= $_GET['msg'];
			$db= new database();
		$postid= $_GET['id'];

		$query= "select * from pendingpost where id= '$postid'";
		$result= $db->select($query);
			if($msg== 1)
			{

				while($row= $result->fetch_assoc()){
				$title= $row['title'];
				$body= $row['body'];
				$author= $row['author'];
				
				$query= "insert into post(title, body, author) values('$title', '$body', '$author')";
				$f= $db->dbinsert($query);
				$query= "delete from pendingpost where id='$postid'";
				$f= $db->dbinsert($query);
				}

			}
			elseif($msg== 2)
			{
				$query= "delete from pendingpost where id='$postid'";
				$f= $db->dbinsert($query);
			}
		

		?>

		
			

		<?php include 'inc/sidebar.php' ?>
	</div>

<?php include 'inc/footer.php' ?>