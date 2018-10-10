<?php
/*
 * Deletes job with given id.
 */
require "/usr/local/Smarty/libs/Smarty.class.php";
require "includes/defs.php";

$id = $_GET['id'];

delete_job($id);

header("Location: job_list_employer.php");
exit;
?>
