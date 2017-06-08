<?php
header("Content-Type: application/json; charset=UTF-8");
require_once('DBConn.php');
class APIRouter{
    public function URLRouting() {
        $endofurl = null;
        $urlPar = null;

        $url = $_SERVER['REQUEST_URI'];
        $url = explode('/', $url);
        $url = array_filter($url);
        $url = array_merge($url, array());
        if(array_key_exists(2, $url)){
          $endofurl = $url[2];
          if(array_key_exists(3, $url)){
            $urlPar = $url[3];
          }
          $this->APISwitching($endofurl, $urlPar);
        }else{
          echo "How on earth did you get here?, Like seriously please tell me?";
        }
        //echo $endofurl;
    }

    private function APISwitching($endofurl, $urlPar){
      $ProcedureCallers = new ProcedureCallers();
      if(method_exists($ProcedureCallers, $endofurl) ){
        $ProcedureCallers->$endofurl(@$urlPar);
      }
      else{
        echo "Not a vaild API";
      }
    }
}

$APIRouter = new APIRouter();
$APIRouter->URLRouting();

class ProcedureCallers{
  public function SelectAllOrders() {
    $dbconn = new DBConnection("warshipsnet");
    if($dbconn){
      $results = array();
      $result = $dbconn->DBQuery("CALL SelectAllOrders()");
      while($row = $result->fetch_assoc()){
        $results[] = $row;
      }
      echo json_encode($results);
    }
  }

  public function SelectAllNations() {
    $result = array();
    $dbconn = new DBConnection("warshipsnet");
    if($dbconn){
      $NationArray = $dbconn->DBQuery("CALL GetAllNations()");
      while($row = $NationArray->fetch_assoc()){
        $dbconn->DBClose();
        $dbconn = new DBConnection("warshipsnet");
        $ID = $row['NationID'];

        $results = array();
        $ShipsArray = $dbconn->DBQuery("CALL SelectShips('$ID')");
        while($row2 = $ShipsArray->fetch_assoc()){
          $results[] = $row2;
        }

        $Nation = array(
          'NationID' => $ID,
          'Name' => $row['Name'],
          'BuildingCapacity' => $row['BuildingCapacity'],
          'NationShips' => $results
        );
        array_push($result, $Nation);
      }
      echo json_encode($result, JSON_PRETTY_PRINT);
    }
  }

  public function DeleteOrder($OrderID) {
    $dbconn = new DBConnection("warshipsnet");
    echo ("Test $OrderID");
    if($dbconn){
      $result = $dbconn->DBQuery("CALL DeleteOrder($OrderID)");
      echo json_encode($result);
    }
  }

  public function DeleteShip($ShipID) {
    $dbconn = new DBConnection("warshipsnet");
    if($dbconn){
      $result = $dbconn->DBQuery("CALL DeleteShip($ShipID)");
      echo json_encode($result);
    }
  }

  public function AddShip(){
    $data = json_decode(file_get_contents('php://input'), true);

    $dbconn = new DBConnection("warshipsnet");
    if($dbconn){
      $result = $dbconn->DBQuery("CALL AddShip('$data[Type]', '$data[Name]', $data[Price], $data[StockQuanitiy], ".((!isset($data[TorpedoBulge]))?"NULL":($data[TorpedoBulge])).", ".((!isset($data[HealAmount]))?"NULL":($data[HealAmount])).", ".((!isset($data[PlaneType]))?"NULL":("'".$data[PlaneType]."'")).", ".((!isset($data[TorpedoTubeCount]))?"NULL":("'".$data[TorpedoTubeCount]."'")).", $data[NationID])");
    }
  }

  public function UpdateShip(){
    $data = json_decode(file_get_contents('php://input'), true);

    $dbconn = new DBConnection("warshipsnet");
    if($dbconn){
      $result = $dbconn->DBQuery("CALL UpdateShip($data[ShipID], '$data[Name]', $data[Price], $data[StockQuanitiy], ".((!isset($data[TorpedoBulge]))?"NULL":($data[TorpedoBulge])).", ".((!isset($data[HealAmount]))?"NULL":($data[HealAmount])).", ".((!isset($data[PlaneType]))?"NULL":("'".$data[PlaneType]."'")).", ".((!isset($data[TorpedoTubeCount]))?"NULL":("'".$data[TorpedoTubeCount]."'")).")");
    }
  }

  public function AddOrder(){
    $data = json_decode(file_get_contents('php://input'), true);

    $dbconn = new DBConnection("warshipsnet");
    if($dbconn){
      $result = $dbconn->DBQuery("CALL AddOrder('$data[UserName]', '$data[Email]', $data[Quantity], $data[ShipID]);");
    }
  }
}

























?>
