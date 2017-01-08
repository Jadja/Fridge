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
					echo '<div id="product">';
					echo '<h2>';
					echo $test[$i]->Name;
					echo '</h2>';
					echo '</div>';
					if ($test[$i]->Name == '')
					{
						$products = $db->SelectAllFromTable('fridge', '', 'JOIN product ON fridge.Product=product.ID WHERE ' . $test[$i]->ID . '=product.Category');
						for ($j = 0; $j < count($products); $j++) 
						{
							echo '<div id="product">';
							echo '<h2>';
							echo $products[$j]->Name;
							echo '</h2>';
							echo '<p>Category: ';
							echo $test[$i]->Name;
							echo '</p>';
							echo '</div>';
						}
					}
				}
				?>
        </main>
    </body>
</html>