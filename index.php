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
			<?php
				$test = $db->SelectAllFromTable('category', '', '');
				for ($i = 0; $i < count($test); $i++) 
				{
					echo '<div id="category"><h2>' . $test[$i]->Name . '</h2></div>';
					$products = $db->SelectAllFromTable('fridge', '', 'JOIN product ON fridge.Product=product.ID WHERE ' . $test[$i]->ID . '=product.Category');
					if(!empty($products))
					{
						for ($j = 0; $j < count($products); $j++) 
						{
							echo '<div id="product"><h2>' . $products[$j]->Name . '</h2><p>Category: ' . $test[$i]->Name . '</p></div>';
						}
					}
				}
				?>
        </main>
    </body>
</html>