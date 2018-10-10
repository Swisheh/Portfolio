<?php
require "/usr/local/Smarty/libs/Smarty.class.php";
require "includes/defs.php";

session_start();
$user = $_SESSION['username'];

if (isset($_GET['error'])) {
    $error = $_GET['error']; 
} else {
    $error = "";
}

if (isset($_GET['query'])) {
    $query = $_GET['query'];
} else {
    $query = "";
}

if (isset($_GET['page'])){
	$page = $_GET['page'];
} else {
	$page = 1;
}

$result = get_jobs_employer($query,$page);
$jobs = $result[0];
$num_jobs = $result[1];
$jobs_per_page = $result[2];

$smarty = new Smarty;

$smarty->assign("user",$user);
$smarty->assign("query",$query);
$smarty->assign("jobs",$jobs);
$smarty->assign("num_jobs",$num_jobs);
$smarty->assign("jobs_per_page",$jobs_per_page);
$smarty->assign("page",$page);

$smarty->display("job_list_employer.tpl");
?>
