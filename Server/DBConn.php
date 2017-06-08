<?php
class DBConnection {
    private $rs; //Procedural "handle" or "resource" to database
    private $connectRs; //ConnectionResource

    private function connectDB($pStrDatabase) //Internal Connection Function
    {
        $this->connectRs = mysqli_connect("Localhost","root","");
        if(!$this->connectRs)
            {
                echo "Error connecting to the server".mysqli_error($this->connectRs);
            }

        $dbRs = mysqli_select_db($this->connectRs,'warshipsnet');
        if(! $dbRs)
            {
                echo "Error selecting the database ".mysqli_error($this->connectRs) . "<br>";
            }
    }

    private function closeDB()
    {
        mysqli_close($this->connectRs);
    }

    public function DBConnection($pStrDatabase) //External Connection Function
    {
        $this->connectDB($pStrDatabase);
    }

    public function DBClose() //External Connection Function
    {
        $this->closeDB();
    }


    public function DBQuery($pStrSQL) //External Query Function
    {
        $this->rs = mysqli_query($this->connectRs,$pStrSQL);
        if( !$this->rs)
        {
            echo "Error running query [$pStrSQL] ".mysqli_error($this->connectRs)."<br>";
        }
        return $this->rs;
    }
}
?>
