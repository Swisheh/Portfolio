<?php
/*
 * Definitions page
 */

require "includes/mysql.php";

/* Show MySQL error. */
function show_error() {
  die("Error ". mysql_errno() . " : " . mysql_error());
}

/* Open connection and select database. */
function mysql_open() {
  $connection = @ mysql_connect(HOST, USER, PASSWORD)
      or die("Could not connect");
  mysql_select_db(DATABASE, $connection)
      or show_error();
  return $connection;
}

/* Adds a new job from form data and returns its id. */
function add_job($id,$title,$description,$location,$salary,$startD,$endD) {
           
    $connection = mysql_open();

    $query = "insert into ld_jobs2 (employerId,title,description,
				location,salary,startdate,enddate) " .
             "values ('$id','$title','$description','$location','$salary',
				from_unixtime($startD),from_unixtime($endD))";
    $results = mysql_query($query,$connection) or show_error();
    $id = mysql_insert_id();
    
    mysql_close($connection) or show_error();
    return $id;
}

/* Gets list of jobs that match $str, if present, in database. */
function get_jobs($str,$page) {
    $connection = mysql_open();

	$jobs_per_page = 4;
	$offset = ($page -1) * $jobs_per_page;
	$time = time();
	
    $query = "select SQL_CALC_FOUND_ROWS ld_jobs2.id, title from ld_jobs2 ";
    if ($str) {
        $query .= ", ld_employers2
					where ld_employers2.industry like '%$str%' 
					or ld_jobs2.location like '%$str%'
					or ld_jobs2.salary > $str
					AND ld_jobs2.employerId = ld_employers2.id ";
    }
	if ($str){ 
		$query .=  "AND ld_jobs2.enddate > from_unixtime($time) ";
	} else {
		$query .=  "where ld_jobs2.enddate > from_unixtime($time) ";
	}
    $query .=  "order by id limit $offset, $jobs_per_page";

    $result = mysql_query($query,$connection) or show_error();
	
	$result2 = mysql_query("select FOUND_ROWS()", $connection) or showerror();
	$row = mysql_fetch_array($result2);
	$num_jobs = $row[0];

    $jobs = array();
    while ($job = mysql_fetch_array($result)) {
        $jobs[] = $job;
    }

    mysql_close($connection) or show_error();
    return array ($jobs, $num_jobs, $jobs_per_page);
}

# Function to return a small list of recently added jobs
function get_recent_jobs(){
	$connection = mysql_open();
	
	$time = time();
	
    $query = "select id, title from ld_jobs2 
			where enddate > from_unixtime($time) 
			order by startdate limit 4";

    $result = mysql_query($query,$connection) or show_error();

    $recents = array();
    while ($recent = mysql_fetch_array($result)) {
        $recents[] = $recent;
    }

    mysql_close($connection) or show_error();
    return $recents;
}

/* Gets list of Employers for Employers home page */
# Needed only in Assignment 1
function get_employers() {
	$connection = mysql_open();
	
	$query = "select id, name, industry, description from ld_employers2 ";
	$query .= "order by id";
	
	$result = mysql_query($query, $connection) or show_error();
	$jobs = array();
	while ($job = mysql_fetch_array($result)){
		$jobs[] = $job;
	}
	
	mysql_close($connection) or show_error();
	return $jobs;
}

/* Gets jobs with given employer id */
function get_jobs_employer($str,$page) {
	$connection = mysql_open();

	$jobs_per_page = 4;
	$offset = ($page -1) * $jobs_per_page;
	
    $query = "select SQL_CALC_FOUND_ROWS ld_jobs2.id, title from ld_jobs2 ";
    if ($str) {
        $query .= ", ld_employers2
					where ld_employers2.industry like '%$str%' 
					or ld_jobs2.location like '%$str%'
					or ld_jobs2.salary > $str
					AND ld_jobs2.employerId = ld_employers2.id ";
    }
    $query .=  "order by id limit $offset, $jobs_per_page";

    $result = mysql_query($query,$connection) or show_error();
	
	$result2 = mysql_query("select FOUND_ROWS()", $connection) or showerror();
	$row = mysql_fetch_array($result2);
	$num_jobs = $row[0];

    $jobs = array();
    while ($job = mysql_fetch_array($result)) {
        $jobs[] = $job;
    }

    mysql_close($connection) or show_error();
    return array ($jobs, $num_jobs, $jobs_per_page);
}

/* Get employer details (name, industry, description) */
# Needed only in Assignment 1
function get_employer_details($id) {
	$connection = mysql_open();
	
	$query = "select name, industry, description 
	          from ld_employers2
			  where id = $id";
	$result = mysql_query($query,$connection) or show_error();
	
	if (mysql_num_rows($result) != 1) {
        echo "Invalid query or result: $query\n";
        die();
    }
    $detail = mysql_fetch_array($result);

    mysql_close($connection) or show_error();
    return $detail;
}

/* Gets job with the given id. */
function get_job($id) {
    $connection = mysql_open();

    $query = "select ld_jobs2.id, ld_employers2.name, title,
           	  ld_jobs2.description, location, salary, startdate, enddate, employerId 
	          from ld_jobs2, ld_employers2 
			  where ld_jobs2.id = $id
			  and ld_jobs2.employerId = ld_employers2.id";
    $result = mysql_query($query,$connection) or show_error();

    if (mysql_num_rows($result) != 1) {
        echo "Invalid query or result: $query\n";
        die();
    }
    $job = mysql_fetch_array($result);

    mysql_close($connection) or show_error();
    return $job;
}

/* Updates an job with the given id using the given title and description. */
function update_job($id,$title,$description,$location,$salary,$startdate,$enddate) {
	$connection = mysql_open();
	
	$title = mysql_real_escape_string($title);
	$description = mysql_real_escape_string($description);
	$query = "update ld_jobs2 " .
			"set title = '$title', description = '$description', " .
			"location = '$location', salary = $salary, startdate = $startdate, enddate = '$enddate' " .
			"where id = $id";
	$result = mysql_query($query, $connection) or show_error();
	mysql_close($connection) or show_error();
}

/* Deletes the job with the given id. */
function delete_job($id) {
	$connection = mysql_open();
	
	$query = "delete 
			from ld_jobs2
			where id = '$id'";
	$result = mysql_query($query, $connection) or show_error();
	mysql_close($connection) or show_error();    
}

/* User Logon */
function login($username,$password){
	$connection = mysql_open();
	
	$salt = substr($username, 0, 2);
	$encryptedPassword = crypt($password, $salt);
	
	$query = "select catagory, employerId from ld_users2 
				where email = '$username' 
				and password = '$encryptedPassword'";
	$result = mysql_query($query, $connection) or show_error();
	
	$result2 = mysql_fetch_array($result);
	
	mysql_close($connection) or show_error();
	
	if ($result2[0] == "administrator"){
		return 2;
	} else if ($result2[0] == "manager"){
		return 3;
	} else {
		return (mysql_num_rows($result) == 1);
	}
}

/* Add user */
function add_user($email,$password,$name,$phone,$image,$details){
	
	$salt = substr($email, 0, 2);
	$storedPassword = crypt($password, $salt);
	
	@$imagedata = addslashes(file_get_contents($image['tmp_name']));
	$imagetype = addslashes($image['type']);
	$imagename = $image['name'];
	
	$connection = mysql_open();
	
	$query = "insert into ld_users2 (email, password, realname, catagory, phone, 
				imagedata, imagename, imagetype, details) 
			values ('$email','$storedPassword','$name','user','$phone',
				'$imagedata','$imagename','$imagetype','$details')";
	$results = mysql_query($query, $connection) or show_error();
	mysql_close($connection) or show_error();
}

# Check current password matches
function checkPass($user,$pass){
	$salt = substr($user, 0, 2);
	$checkPassword = crypt($pass,$salt);
	
	$connection = mysql_open();
	
	$query = "select * from ld_users2 
				where email = '$user' 
				and password = '$checkPassword'";
	$result = mysql_query($query, $connection) or show_error();
	
	mysql_close($connection) or show_error();
	
	return (mysql_num_rows($result) == 1);
}

# Update current password to new password
function updatePass($user,$newP){
	$salt = substr($user, 0, 2);
	$newPassword = crypt($newP,$salt);
	
	$connection = mysql_open();
	
	$query = "update ld_users2 " .
			"set password = '$newPassword' 
			where email = '$user'";
	$result = mysql_query($query, $connection) or show_error();
	
	mysql_close($connection) or show_error();
}

# Get employer Id for verification
function getId($user){
	$connection = mysql_open();
	
	$query = "select employerId from ld_users2 
				where email = '$user'";
	$results = mysql_query($query, $connection) or show_error();
	
	$id = mysql_fetch_array($results);
	$id2 = $id[0];
	
	mysql_close($connection) or show_error();
	return $id2;
}

# Get real name of the user
function getname($user){
	$connection = mysql_open();
	
	$query = "select realname from ld_users2
				where email = '$user'";
	$result = mysql_query($query, $connection) or show_error();
	
	$user = mysql_fetch_array($result);
	$user2 = $user[0];
	
	mysql_close($connection) or show_error();
	return $user2;
}

# Add an application to the ld_apps2 database
function add_app($user, $job, $letter, $date){
	$connection = mysql_open();
	
	$query = "insert into ld_apps2 (applicant, jobId, letter, appdate)
				values ('$user','$job','$letter',from_unixtime($date))";
	$result = mysql_query($query, $connection) or show_error();
	
	mysql_close($connection) or show_error();
}

# Check if a user has already applied for this job
function applied($user){
	$connection = mysql_open();
	
	$query = "select applicant from ld_apps2 where applicant = '$user'";
	$result = mysql_query($query, $connection) or show_error();
	
	mysql_close($connection) or show_error();
	return (mysql_num_rows($result) == 1);
}

# To show the employer a list of applicants to their job
function get_apps($id){
	$connection = mysql_open();
	
	$query = "select applicant from ld_apps2 where jobId = '$id'";
	$result = mysql_query($query, $connection) or show_error();
	
	$apps = array();
    while ($app = mysql_fetch_array($result)) {
        $apps[] = $app;
    } 
	
	mysql_close($connection) or show_error();
	return $apps;
}

# Get details of an applicant
function get_app($app){
	$connection = mysql_open();
	
	$query = "select realname, phone, details, letter, appdate 
				from ld_users2, ld_apps2 
				where realname = '$app' 
				AND applicant = '$app'";
	$result = mysql_query($query, $connection) or show_error();
	
	$apps = mysql_fetch_array($result);
	mysql_close($connection) or show_error();
	return $apps;
}

# Get details of the users photo
function get_photo($name){
	$connection = mysql_open();
		
	$query = "select imagedata, imagetype " .
			"from ld_users2 where realname = '$name'";
	$result = @ mysql_query($query, $connection)
			or show_error();
	$image = mysql_fetch_array($result);
	
	return $image;
}