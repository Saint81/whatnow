<?php


function readWhatNowLog($_fileName, &$_responses, &$queryName)
{
	if( file_exists($_fileName) )
		$f = fopen($_fileName, "rb");
	
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
			$_responses[$response] = $value;
		}
		
		fclose($f);
	}
	else return false;
	
	return true;
}


$id = $_GET['id'];
$fileName = "data/" . $id . ".txt";
$oldFile = "data/" . $id . ".old";
$cleanup = isset($_GET['cleanup']);
if( isset($_GET['query']) )
{
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
else if( !$cleanup )
{
	$hasQuery = true;
	if( !readWhatNowLog($fileName, $responses, $queryName) )
		$hasQuery = false;
}

if( isset($_GET['getresponse']) )
{
	if( $hasQuery )
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
		for( $i = 0; $i < 10; $i++ )
		{
			$f = fopen($oldFile, "wb");
			if( $f !== FALSE )
				break;
		}
		if( $i >= 10 )
		{
			die("FAIL" . $fileName);
		}
		fwrite($f, $queryName . ";");
		
		foreach( $responses as $key => $value )
		{
			echo $key . "=" . $value . ";";
			fwrite($f, $key . ";" . $value . ";");
		}
		fclose($f);
	}
}
else if( $cleanup )
{
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
}
else if( !isset($_GET['query']) )
{
	$oldCount = -1;
	if(readWhatNowLog($oldFile, $oldResponses, $ignored))
	{
		foreach( $oldResponses as $key => $value )
		{
			if( $value > $oldCount )
			{
				$oldCount = $value;
				$oldWinner = $key;
			}
			else if( $value == $oldCount )
				$oldWinner = "UNDECIDED";
		}
	}

	echo '<!DOCTYPE html><html><head>';
	echo '<link type="text/css" rel="stylesheet" href="stylesheet.css"/>';
	
	$isButton = isset($_GET['button']);
	echo '<meta http-equiv="refresh" content="4; URL=http://www.backworlds.com/whatnow/?id=' . $id . '" />';

	if( $isButton )
	{
		if( isset($responses[$_GET['button']]) && $hasQuery )
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

		echo '<h1>WHAT DO WE DO NOW?</h1>';
		echo '<div id="menu">';
		echo '<div id="picture">';
        echo '<img src="img/' . $queryName . '">';
		echo '</div>';
		echo '<h1>VOTE NOW</h1>';
		foreach( $responses as $key => $value )
		{
			echo '<h2><a href="http://www.backworlds.com/whatnow/index.php?id=' . $id . '&button=' . $key . '">'.$key.'</a></h2>';
		}
	}
	else
	{
		echo '<title>UNAPPROVED REQUEST</title>';
		echo '</head>';
		echo '<body>';
		echo '<div class="all">';
		echo '<div class="main">';
		echo '<h1>STAND BY FOR INSTRUCTION<br/><br/>NONCOMFORMITY GUARANTEES REEDUCATION</h1>';
		echo '<div id="menu">';
	}
	
	echo '</div>';
	echo '</div>';
	echo '<div id="footer"><p>';
	if( $oldCount >= 0 )
	{
		echo 'PREVIOUS ACTION ' . $oldWinner . ', ' . $oldCount . ' VOTES<br />';
	}
	echo 'ALL OTHER INFORMATION IS USELESS</p></div>';
	echo '</div>';
	echo '</body>';
}


?>