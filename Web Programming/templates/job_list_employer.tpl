<!DOCTYPE HTML>
<html>
<head>
{if $user}
	{include 'header.tpl' title="Job List" user="Logged in as: $user"}
{else}
	{include 'header.tpl' title="Home page"}
{/if}
</head>

<body>
{if $query}
<h1>Jobs for '{$query}'</h1>
{else}
<h1>Jobs</h1>
{/if}
    
{if $jobs}
<ul>
{foreach $jobs as $job}
    <li><a href="job_detail_employer.php?id={$job.id}">{$job.title|escape}</a></li>
{/foreach}
</ul>
{else}
<p>No jobs found.</p>
{/if}

{if ($page-1) ==0}
	<p>Prev
{else}
	<p><a href="job_list_employer.php?page={$page - 1}">Prev</a>
{/if}

{for $pages=1 to ceil($num_jobs/$jobs_per_page)}
	<a href="job_list_employer.php?page={$pages}">{$pages}</a>
{/for}

{if $page ==ceil($num_jobs/$jobs_per_page)}
	Next
{else}
	<a href="job_list_employer.php?page={$page + 1}">Next</a>
{/if}
</p>

<form method="get" action="job_list.php">
<table>
<tr><td class="col2">Search: </td><td><input type="text" name="query"> 
	<input type="submit" value="Go"><td><tr>
</table>
</form>

<p><a href="index.php">Home</a></p>

<h2>Add new job</h2>
<form method="post" action="add_job_action.php">
    <table>
    <tr><td class="col2">Title:</td> <td><input type="text" name="title"></td></tr>
    <tr><td class="col2">Description:</td> <td><textarea name="description"></textarea></td></tr>
	<tr><td class="col2">Location:</td> <td><input type="text" name="location"></td></tr>
	<tr><td class="col2">Salary:</td> <td><input type="number" name="salary"></td></tr>
	<tr><td class="col2">Application Start Date:</td> <td><input type="date" name="startD" 
		value="YYYY-MM-DD"></td></tr>
	<tr><td class="col2">Application End Date:</td> <td><input type="date" name="endD" 
		value="YYYY-MM-DD"></td></tr>
    <tr><td colspan=2><input type="submit" value="Add job">
    </table>
</form>

<hr>
	Created by: Rory Hiscock <br>

</body>
</html>
