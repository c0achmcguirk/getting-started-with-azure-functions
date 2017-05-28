<?php

  include "library.php";

  # read from the query string
  echo("\n---------------------------------");
  $inputVal = getEnv('REQ_QUERY_nums');
  echo("\nRead in input nums as $inputVal");
  $numbers = explode(",", $inputVal);
  echo("\nRead in numbers as " . implode(",", $numbers));

  $local_sum = add($numbers[0], $numbers[1]);
  $lib_sum = libAdd($numbers[0], $numbers[1]);

  echo("\nThe sum (local) is $local_sum");
  echo("\nThe sum (from library) is $lib_sum");

  $myResponse = array(
    "inputs" => $inputVal,
    "localSum" => $local_sum,
    "libSum" => $lib_sum
  );

  # output the sums in the response
  file_put_contents(getenv('res'), json_encode($myResponse));
?>

