<!DOCTYPE HTML>
<html>
<head>
{if $user}
	{include 'header.tpl' title="Job list" user="Logged in as: $user"}
{else}
	{include 'header.tpl' title="Home page"}
{/if}
</head>

<body>
{if $query}
<h1>Jobs for '{$query}'</h1>
{else}
<h1>Recent Jobs</h1>
{if $recents}
<ul>
{foreach $recents as $recent}
    <li><a href="job_detail.php?id={$recent.id}">{$recent.title|escape}</a></li>
{/foreach}
</ul>
{else}
<p>No recent jobs found.</p>
{/if}

<h1>All Jobs</h1>
{/if}
    
{if $jobs}
<ul>
{foreach $jobs as $job}
    <li><a href="job_detail.php?id={$job.id}">{$job.title|escape}</a></li>
{/foreach}
</ul>
{else}
<p>No jobs found.</p>
{/if}

{if ($page-1) ==0}
	<p>Prev
{else}
	<p><a href="job_list.php?page={$page - 1}">Prev</a>
{/if}

{for $pages=1 to ceil($num_jobs/$jobs_per_page)}
	<a href="job_list.php?page={$pages}">{$pages}</a>
{/for}

{if $page ==ceil($num_jobs/$jobs_per_page)}
	Next
{else}
	<a href="job_list.php?page={$page + 1}">Next</a>
{/if}
</p>

<form method="get" action="job_list.php">
<table>
<tr><td class="col2">Search: </td><td><input type="text" name="query"> <input type="submit" value="Go"></td></tr>
</table>
</form>

<p><a href="index.php">Home</a></p>

<hr>
Created by: Rory Hiscock <br>
</body>
</html>
