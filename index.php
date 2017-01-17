<?php
require_once('init.php');
?>
<doctype html>

<html>
    <head>
        <title>FiFo - My Products</title>
        <meta charset='utf-8'>
        <link rel='shortcut icon' href='favicon.ico'>
        <link rel='stylesheet' href='assets/css/style.css' type='text/css' />
        <script src='https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js'></script>
    </head>
    <body>
	<div id="fixed"><p><a href="no_cat.php">NO CATEGORIES</a></p></div>
        <main>
            <nav>
                <ul>
					<li><a href="index.php">My Products</a></li>
					<li><a href="products.php">All Products</a></li>
                </ul>
            </nav>
			<?php
				$test = $db->SelectAllFromTable('category', '', '');
				for ($i = 0; $i < count($test); $i++) 
				{
					$products = $db->SelectAllFromTable('food', '', "JOIN product ON food.Product=product.ID WHERE product.Category='" . $test[$i]->Name . "' ORDER BY DATE_ADD(food.Add_date, INTERVAL product.Expiration_time DAY) asc");
					if(empty($products))
					{
						echo '<div id="category"><div id="sub"><h1>' . $test[$i]->Name . '</h1><h2>0 Items</h2></div></div>';
					}
					else
					{
						$ProductDivs = "";
						for ($j = 0; $j < count($products); $j++)
						{
							$product = $db->SelectAllFromTable('product', '', 'JOIN food ON product.ID=food.Product WHERE ' . $products[$j]->Product . '=product.ID');
							
							$now = time();
							$date = strtotime($products[$j]->Add_date);
							
							$diff = $now - $date;
							
							$timeleft = $product[0]->Expiration_time - (floor($diff / (60 * 60 * 24)));
							$divcolor = ($timeleft) / 5;
							if($divcolor < 0)
							{
								$divcolor = 0;
							}
							
							switch (ceil($divcolor))
							{
								case 0:
									$ProductDivs .= '<div id="colordiv" style="background-color:#FF4136"></div>';
									break;
								case 1:
									$ProductDivs .= '<div id="colordiv" style="background-color:#FF851B"></div>';
									break;
								case 2:
									$ProductDivs .= '<div id="colordiv" style="background-color:#FFDC00"></div>';
									break;
								case 3:
									$ProductDivs .= '<div id="colordiv" style="background-color:#01FF70"></div>';
									break;
								case 4:
									$ProductDivs .= '<div id="colordiv" style="background-color:#2ECC40"></div>';
									break;
								default:
									$ProductDivs .= '<div id="colordiv" style="background-color:#3D9970"></div>';
									break;
							}
							if($j > 7)
							{
								$j = 99999;
							}
						}
						echo '<div id="category"><div id="sub"><h1>' . $test[$i]->Name . '</h1><h2>' . count($products) . ' Items</h2></div><div id="sub">' . $ProductDivs . '</div></div>';
					}
					if(!empty($products))
					{
						for ($j = 0; $j < count($products); $j++) 
						{
							$product = $db->SelectAllFromTable('product', '', 'JOIN food ON product.ID=food.Product WHERE ' . $products[$j]->Product . '=product.ID');
							
							$description = $products[$j]->Description;
							if(strlen($products[$j]->Description) > 50)
							{
							$description = substr($description, 0, 50);
							$description .= '...';
							}
							
							$now = time();
							$date = strtotime($products[$j]->Add_date);
							
							$diff = $now - $date;
							
							$timeleft = $product[0]->Expiration_time - (floor($diff / (60 * 60 * 24)));
							$divcolor = ($timeleft) / 5;
							if($timeleft < 0)
							{
								$timeleft = 'EXPIRED';
							}
							else
							{
								$timeleft = 'Expires In: ' . $timeleft . ' Days';
							}
							if($divcolor < 0)
							{
								$divcolor = 0;
							}
							
							switch (ceil($divcolor))
							{
								case 0:
									echo '<div id="product" style="background-color:#FF4136"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
									break;
								case 1:
									echo '<div id="product" style="background-color:#FF851B"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
									break;
								case 2:
									echo '<div id="product" style="background-color:#FFDC00"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
									break;
								case 3:
									echo '<div id="product" style="background-color:#01FF70"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
									break;
								case 4:
									echo '<div id="product" style="background-color:#2ECC40"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
									break;
								default:
									echo '<div id="product" style="background-color:#3D9970"><div id="sub"><h1>' . $products[$j]->Name . '</h1><p>' . $description . '</p></div><div id="sub"><h3>' . $timeleft . '</h3></div></div>';
									break;
							}
							
						}
					}
				}
				?>
				<div>My Products</div>
        </main>
    </body>
</html>