<?php
require_once('init.php');
?>
<doctype html>

<html>
    <head>
        <title>Fridge Thing</title>
        <meta charset='utf-8'>
        <link rel='shortcut icon' href='favicon.ico'>
        <link rel='stylesheet' href='assets/css/style.css' type='text/css' />
        <script src='https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js'></script>
        <script src='assets/javascript/nav.js'></script>
    </head>
    <body>
        <main>
            <nav>
                <ul>
                </ul>
            </nav>
			<div id="product" style="background-color:blue">
				<h1>Category</h1>
			</div>
			<div id="product" style="background-color:blue">
				<h1>Category</h1>
			</div>
			<div id="product" style="background-color:blue">
				<h1>Vlees & Vis</h1>
				<p>This category is currently selected</p>
			</div>
			<div id="product" style="background-color:red">
				<h2>Kip</h2>
				<p>Houdbaar tot: Vandaag (over 0 dagen)</p>
			</div>
			<div id="product" style="background-color:yellow">
				<h2>Koe</h2>
				<p>Houdbaar tot: 15-12-2016 (over 2 dagen)</p>
			</div>
			<div id="product" style="background-color:yellow">
				<h2>Varken</h2>
				<p>Houdbaar tot: 17-12-2016 (over 4 dagen)</p>
			</div>
			<div id="product" style="background-color:green">
				<h2>Kogelvis</h2>
				<p>Houdbaar tot: 24-12-2016 (over 11 dagen)</p>
			</div>
			<div id="product" style="background-color:green">
				<p>Filler</p>
			</div>
			<div id="product" style="background-color:green">
				<p>Filler</p>
			</div>
			<div id="product" style="background-color:green">
				<p>Filler</p>
			</div>
			<div id="product" style="background-color:green">
				<p>Filler</p>
			</div>
			<div id="product" style="background-color:lightgreen">
				<p>Filler</p>
			</div>
			<div id="product" style="background-color:lightgreen">
				<p>Filler</p>
			</div>
			<div id="product" style="background-color:blue">
				<h1>Category</h1>
			</div>
			<div id="product" style="background-color:blue">
				<h1>Category</h1>
			</div>
			<div id="product" style="background-color:blue">
				<h1>Category</h1>
			</div>
            <p>
            <?php
            /*$test = $db->SelectAllFromTable('category', '', '');
            for ($i = 0; $i < count($test); $i++) {
                echo $test[$i]->Name . '<br />';
            }*/
            ?>
            </p>
        </main>
    </body>
</html>