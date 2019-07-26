<?php

class format
{
	public function formatDate($date)
	{
		return date('F j, y, g:i a', strtotime($date));
	}

	public function textShortening($text, $limit= 400)
	{
		$len= strlen($text);
		if($len<$limit) return $text;
		$ret= "";
		for($i= 0; $i<$len; $i++)
		{
			$ret.= $text[$i];
			if($i>=$limit)
			{
				break;
			}
		}
		$i++;
		while($text[$i]!= " ")
		{
			$ret.= $text[$i];
			$i++;
		}

		return $ret;
	}
}


?>