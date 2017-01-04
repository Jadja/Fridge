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
				<h2>
				<?php
				$test = $db->SelectAllFromTable('category', '', '');
				for ($i = 0; $i < count($test); $i++) 
				{
					echo $test[0]->Name . '<br />';
				}
				?>
				</h2>
			</div>
			<div id="product" style="background-color:red">
				<h2>
				<?php
				$test = $db->SelectAllFromTable('fridge', '', '');
				for ($i = 0; $i < count($test); $i++) 
				{
					echo $test[0]->ID . '<br />';
				}
				?>
				</h2>
			</div>
        </main>
    </body>
</html>