<?php
include('database.php');
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>List of users</title>
</head>

<body>

    <?php 
    if ($_SERVER['PHP_SELF'] == "/") {
        $list = mysqli_query($mysqli, "SELECT * FROM users");
        while ($row = mysqli_fetch_array($list))  {
        ?>
    <a href="/user/<?php echo $row["uid"]; ?>"><?php echo $row["username"]; ?></a><br>
    <?php
        }
    } else {
        $uid = str_replace("/user/","",$_SERVER['PHP_SELF']);
        $checker = is_numeric($uid);
        if ($checker == true) {
            $orders = mysqli_query($mysqli, "SELECT u.username, u.full_name, u.email, p.pname, a.adress, a.zip, a.city, a.country FROM orders INNER JOIN users AS u ON u.uid = orders.uid INNER JOIN products as p ON p.pid = orders.pid INNER JOIN address AS a ON u.aid = a.aid WHERE orders.uid = $uid");
            $data = [];

            while($row = mysqli_fetch_array($orders)){
                array_push($data, $row);
            } 

            echo $data[0]["username"] . " / " . $data[0]["email"] . " / " . $data[0]["full_name"] . "<br>";
            echo $data[0]["adress"] . " / " . $data[0]["city"] . " / " . $data[0]["country"] . " / " . $data[0]["zip"] . "<br>";
            echo "User id: " . $uid . "<br>";
              
            foreach($data as $item){
                echo $item['pname'].'<br>';
            }

        } else {
            echo "No User id found<br>";
        }

        echo '<a href="/">Home</a>';
    }
    ?>
</body>

</html>