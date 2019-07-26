<?php include 'inc/header.php' ?>
<?php include 'Database/database.php' ?>
<?php include 'helpers/format.php'?>

<?php
$userid= $_GET['userid'];
$db= new database();
$postid= $_GET['id'];
$query= "select * from post where id= '$postid'";
$result= $db->select($query);
$format= new format();

$query= "select * from question where pid= '$postid'";
$question= $db->select($query);
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
				<li><a href="compose.php?userid=<?php echo $userid; ?>">Admin Panel</a></li>
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



		<div class="maincontent clear about">
				
			<h2>Multiple Choice Question Test</h2>
			<form action="" method="post">
			<?php if($question){ while($row= $question->fetch_assoc()){ ?>
				<p><b><?php echo $row['qid']; ?>. <?php echo $row['question'] ?></b></p>

				<input type="radio" name="<?php echo $row['qid'] ?>" value= "a"> <?php echo $row['opta'] ?> <br>
				<input type="radio" name="<?php echo $row['qid'] ?>" value= "b"> <?php echo $row['optb'] ?> <br>
				<input type="radio" name="<?php echo $row['qid'] ?>" value= "c"> <?php echo $row['optc'] ?> <br>
				<input type="radio" name="<?php echo $row['qid'] ?>" value= "d"> <?php echo $row['optd'] ?> <br><br>


			<?php }?>
			<input type="submit" name="submit" value= "Submit Answer">

		<?php }else{
				echo "<p style= 'color: red'><b>No MCQ Test yet ready for this Post.</b><p>";
			} ?>
			</form>
		</div>

		<?php if(isset($_POST['submit'])){ ?>
		<div class= "maincontent clear">
			<?php 
				$numberOfQuestions= 5;//later on we will take dynamically
				$cnt= 0;
				$flag= 0;
				for($i= 1; $i<=$numberOfQuestions; $i++)
				{
					if(isset($_POST[$i])) $value= $_POST[$i];
					else 
					{
						echo "<b style= 'color: red'>Please Submit all the answers...</b>";
						$flag= 1;
						break;
					}
					$query= "select * from question where pid= '$postid' and qid= '$i'";
					$result= $db->select($query);
					$row= $result->fetch_assoc();
					$answer= $row['ans'];
					
					if($value== $answer) $cnt++;
				}

				if(!$flag) $points= ($cnt/$numberOfQuestions)*100;
			?>
			<?php if(!$flag) {?><h3>You got Points: <?php echo $points ?>% and It'll be added to your Profile Rating</h3>

			<?php
			$query= "select * from user where id= '$userid'";
			$result= $db->select($query);
			$row= $result->fetch_assoc();

			$participated= $row['no_of_test'];
			$total= $row['total_marks'];

			$participated++;
			$total+= $points;

			$query= "update user set no_of_test= '$participated', total_marks= '$total' where id= '$userid'";

			$db->dbupdate($query);



			?>
		<?php }?>
		</div>
	<?php } ?>

		<?php include 'inc/sidebar.php' ?>
	</div>

<?php include 'inc/footer.php' ?>