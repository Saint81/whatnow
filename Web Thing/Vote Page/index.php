<?php

$id = $_GET['id'];
$fileName = "data/" . $id . ".txt";
$oldFile = "data/" . $id . ".old";
if( isset($_GET['query']) )
{
	unlink($oldFile);
	for( $i = 0; $i < 10; $i++ )
	{
		$f = fopen($fileName, "wb");
		if( $f !== FALSE )
			break;
	}
	if( $i >= 10 )
	{
		die("FAIL" . $fileName);
	}
	
	fwrite($f, $_GET['query'] . ";");
	$index = 0;
	while( isset($_GET["response".$index]) )
	{
		fwrite($f, $_GET["response".$index] . ";0;");
		$index++;
	}
	fclose($f);
	
	echo "SUCCESS";
}
else
{
	$isOld = false;
	$hasQuery = true;
	if( file_exists($fileName) )
		$f = fopen($fileName, "rb") or die("FAIL (read)");
	else if( file_exists($oldFile) )
	{
		$f = fopen($oldFile, "rb") or die("FAIL (read)");
		$isOld = true;
	}
	else
	{
		$hasQuery = false;
	}
	
	if( isset($f) )
	{
		$rd = '';
		$queryName = '';
		while( $rd != ';' )
		{
			$queryName .= $rd;
			$rd = fread($f, 1);
		}
		
		$rd = fread($f,1);
		while( !feof($f) )
		{
			$response = '';
			while( $rd != ';' )
			{
				$response .= $rd;
				$rd = fread($f, 1) or die("FAIL (response)");
			}
			
			$rd = fread($f,1);
			$value = '';
			while( $rd != ';' )
			{
				$value .= $rd;
				$rd = fread($f, 1) or die("FAIL (id)");
			}
			
			$rd = fread($f, 1);
			$responses[$response] = $value;
		}
		
		fclose($f);
	}
}

if( isset($_GET['getresponse']) )
{
	if( !$isOld )
	{
		unlink($fileName);
		
		if ($handle = opendir('data')) {
			while (false !== ($entry = readdir($handle))) {
				if (strpos($entry, $id) === false)
					continue;
				
				$nameEnd = strpos($entry, "#");
					
				$startPos = strlen($id);
				$ID = substr($entry, $startPos, $nameEnd - $startPos);
				
				if( isset($responses[$ID]) )
					$responses[$ID] ++;
					
				unlink('data/' . $entry);
			}
			
			closedir($handle);
		}

		// write old file
		$f = fopen($oldFile, "wb") or die("FAIL (write old)");
		fwrite($f, $queryName . ";");
		
		foreach( $responses as $key => $value )
		{
			echo $key . "=" . $value . ";";
			fwrite($f, $key . ";" . $value . ";");
		}
		fclose($f);
	}
}
else if( !isset($_GET['query']) )
{

	echo '<!DOCTYPE html><html><head>';
	echo '<link type="text/css" rel="stylesheet" href="stylesheet.css"/>';
	
	$isButton = isset($_GET['button']);
	if( !isButton || !$isOld )
		echo '<meta http-equiv="refresh" content="4; URL=http://www.backworlds.com/whatnow/?id=' . $id . '" />';

	if( $isButton )
	{
		if( isset($responses[$_GET['button']]) && !$isOld )
		{
			// Create new file with ID and response
			$voteName = "data/" . $id . $_GET['button'] . "#" . $_SERVER['REMOTE_ADDR'];
			$f = fopen($voteName, "wb") or die("FAIL (vote)");
			fwrite($f, "!");
			fclose($f);
			echo "<title>GOOD JOB</title>";
			echo '<div class="all">';
			echo '<div class="main">';
			echo '<h1>INPUT ACCEPTED<br/>STAND BY FOR INSTRUCTIONS</h1>';
			echo '<div id="menu">';
		}
		else
		{
			echo '<title>TOO LATE</title>';
			echo '</head>';
			echo '<body>';
			echo '<div class="all">';
			echo '<div class="main">';
			echo '<h1>ACCESS DENIED<br>TOO LATE!<br>404 CREDIT FINE IS APPLICABLE</h1>';
			echo '<div id="menu">';
		}
	}
	else if( $hasQuery )
	{
		echo '<title>WHAT NOW??</title>';
		echo '</head>';
		echo '<body>';
		echo '<div class="all">';
		echo '<div class="main">';

		if( $isOld )
		{
			echo '<h1>YOUR COOPERATION IS CORRECT</h1>';
			echo '<div id="menu">';
			echo '<div id="menu">';
			echo '<h1>VOTE RESULTS</h1>';
			
			foreach( $responses as $key => $value )
			{
				echo '<h2>' . $key . ' >> ' . $value . '</h2>';
			}
			
			echo '</div>';
		}
		else
		{        
			echo '<h1>WHAT DO WE DO NOW?</h1>';
			echo '<div id="menu">';
			echo '<div id="picture">';
            // echo '<img src="img/pic_1.png">';
			echo '</div>';
			echo '<h1>VOTE NOW</h1>';
			foreach( $responses as $key => $value )
			{
				echo '<h2><a href="http://www.backworlds.com/whatnow/index.php?id=' . $id . '&button=' . $key . '">'.$key.'</a></h2>';
			}
		}
	}
	else
	{
		echo '<title>UNAPPROVED REQUEST</title>';
		echo '</head>';
		echo '<body>';
		echo '<div class="all">';
		echo '<div class="main">';
		echo '<h1>UNAPPROVED REQUEST<br/><br/>NONCOMFORMITY FINE IS APPLICABLE</h1>';
		echo '<div id="menu">';
	}
	
	echo '</div>';
	echo '</div>';
	echo '<div id="footer"><p>ALL INFORMATION IS USELESS</p></div>';
	echo '</div>';
	echo '</body>';
}


?>