<?php
/*
* To return the image
*/
require "includes/defs.php";

$id = $_GET['id'];

$image = get_photo($id);

$data = $image['imagedata'];
$type = $image['imagetype'];

header("Content-type: $type");
echo $data;
?>