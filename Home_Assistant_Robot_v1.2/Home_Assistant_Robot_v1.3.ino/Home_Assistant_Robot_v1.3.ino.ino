/******************************************************************************************************************************
*** "In the name of Allah(swt), the most gracious, most merciful. Allah(swt) blesses with knowledge to whom he wants."      ***
***     Author     : Mahi Al Jawad                                                                                          ***
***     University : Dept. of CSE, IIUC                                                                                     ***
***     github     : https://github.com/MahiAlJawad                                                                         ***
***     Email      : br.mahialjawad@gmail.com                                                                               ***
***     facebook   : https://www.facebook.com/jawad.wretched                                                                ***
*******************************************************************************************************************************/

/*EXPLANATION for used VARIABLE NAMES: f stands for "front" , b stands for "back" , r stands for "right" , l stands for "left" , p stands for "positive" and n stands for "negative"
for example frn means "front right positive" pin */ 

#define frp A2
#define frn A3
#define flp A0
#define fln A1
#define brp 2
#define brn 4
#define blp 7
#define bln 8

void hault()
{
  digitalWrite(frp, LOW);
  digitalWrite(frn, LOW);
  digitalWrite(flp, LOW);
  digitalWrite(fln, LOW);
  digitalWrite(brp, LOW);
  digitalWrite(brn, LOW);
  digitalWrite(blp, LOW);
  digitalWrite(bln, LOW);
}
void forward()
{
  digitalWrite(frp, HIGH);
  digitalWrite(frn, LOW);
  digitalWrite(flp, HIGH);
  digitalWrite(fln, LOW);
  digitalWrite(brp, HIGH);
  digitalWrite(brn, LOW);
  digitalWrite(blp, HIGH);
  digitalWrite(bln, LOW);
}
void backward()
{
  digitalWrite(frp, LOW);
  digitalWrite(frn, HIGH);
  digitalWrite(flp, LOW);
  digitalWrite(fln, HIGH);
  digitalWrite(brp, LOW);
  digitalWrite(brn, HIGH);
  digitalWrite(blp, LOW);
  digitalWrite(bln, HIGH);
}
void left()
{
  digitalWrite(frp, HIGH);
  digitalWrite(frn, LOW);
  digitalWrite(flp, LOW);
  digitalWrite(fln, HIGH);
  digitalWrite(brp, HIGH);
  digitalWrite(brn, LOW);
  digitalWrite(blp, LOW);
  digitalWrite(bln, HIGH);
  delay(410);//410 ms for 90 degree rotation
  hault();
}

void right()
{
  digitalWrite(frp, LOW);
  digitalWrite(frn, HIGH);
  digitalWrite(flp, HIGH);
  digitalWrite(fln, LOW);
  digitalWrite(brp, LOW);
  digitalWrite(brn, HIGH);
  digitalWrite(blp, HIGH);
  digitalWrite(bln, LOW);
  delay(410);//410 ms for 90 degree rotation
  hault();
}

void turnOpposite()
{
  digitalWrite(frp, HIGH);
  digitalWrite(frn, LOW);
  digitalWrite(flp, LOW);
  digitalWrite(fln, HIGH);
  digitalWrite(brp, HIGH);
  digitalWrite(brn, LOW);
  digitalWrite(blp, LOW);
  digitalWrite(bln, HIGH);
  delay(805);
  hault();
}


void setup()
{
  pinMode(frp, OUTPUT);
  pinMode(frn, OUTPUT);
  pinMode(flp, OUTPUT);
  pinMode(fln, OUTPUT);
  pinMode(brp, OUTPUT);
  pinMode(brn, OUTPUT);
  pinMode(blp, OUTPUT);
  pinMode(bln, OUTPUT);
  Serial.begin(9600);
}

char currentPosition= '1';

void loop()
{
  
  while(Serial.available())
  {
    Serial.print("\nCurrent Position: ");
    Serial.print(currentPosition);
    Serial.print("\n");
    
    
    char destination= Serial.read();
    
    Serial.print("\nDestination: ");
    Serial.print(destination);
    Serial.print("\n");

    if(currentPosition== destination) Serial.print("Not Possible goint from same room to same room");
    
    if(currentPosition== '1')
    {
      if(destination== '2')
      {
        Serial.print("\n");
        Serial.print("Goint to destination 2");
        Serial.print("\n");

        forward();
        delay(980);
        hault();
        delay(1000);
        turnOpposite();
        currentPosition= destination;
        
        Serial.print("\n");
        Serial.print("Reached destination 2");;
        Serial.print("\n");
        
      }
      else if(destination== '3')
      {
        Serial.print("\n");
        Serial.print("Goint to destination 3");
        Serial.print("\n");
       
        forward();
        delay(500);
        hault();
        delay(1000);
        left();
        delay(1000);
        forward();
        delay(1000);
        hault();
        delay(1000);
        right();
        delay(1000);
        forward();
        delay(500);
        hault();
        delay(1000);
        turnOpposite();
        currentPosition= destination;
 
        Serial.print("\n");
        Serial.print("Reached destination 3");;
        Serial.print("\n");
      }
      else if(destination== '4')
      {
        Serial.print("\n");
        Serial.print("Goint to destination 4");
        Serial.print("\n");
       
        forward();
        delay(500);
        hault();
        delay(1000);
        left();
        delay(1000);
        forward();
        delay(1000);
        hault();
        delay(1000);
        left();
        delay(1000);
        forward();
        delay(500);
        hault();
        delay(1000);
        turnOpposite();

        currentPosition= destination;
 
        Serial.print("\n");
        Serial.print("Reached destination 4");;
        Serial.print("\n");
      }
    }
    else if(currentPosition== '2')
    {
      if(destination== '1')
      {
        Serial.print("\n");
        Serial.print("Goint to destination 1");
        Serial.print("\n");

        forward();
        delay(980);
        hault();
        delay(1000);
        turnOpposite();
        currentPosition= destination;
        
        Serial.print("\n");
        Serial.print("Reached destination 1");;
        Serial.print("\n");
      }
      else if(destination== '4')
      {
        Serial.print("\n");
        Serial.print("Goint to destination 4");
        Serial.print("\n");

        forward();
        delay(500);
        hault();
        delay(1000);

        right();
        delay(1000);

        forward();
        delay(1000);
        hault();
        delay(1000);

        left();
        delay(1000);

        forward();
        delay(500);
        hault();
        delay(1000);

        turnOpposite();

        currentPosition= destination;

        Serial.print("\n");
        Serial.print("Reached destination 4");;
        Serial.print("\n");
      }
      else if(destination== '3')
      {
        Serial.print("\n");
        Serial.print("Goint to destination 3");
        Serial.print("\n");

        forward();
        delay(500);
        hault();
        delay(1000);
        
        right();
        delay(1000);
        
        forward();
        delay(1000);
        hault();
        delay(1000);
        
        right();
        delay(1000);
        
        forward();
        delay(500);
        hault();
        delay(1000);
        
        turnOpposite();

        currentPosition= destination;

        Serial.print("\n");
        Serial.print("Reached destination 3");;
        Serial.print("\n");
      }
    }
    else if(currentPosition== '3')
    {
      if(destination== '1')
      {
        Serial.print("\n");
        Serial.print("Goint to destination 1");
        Serial.print("\n");
       
        forward();
        delay(500);
        hault();
        delay(1000);
        
        left();
        delay(1000);
        
        forward();
        delay(1000);
        hault();
        delay(1000);
        
        right();
        delay(1000);
        
        forward();
        delay(500);
        hault();
        delay(1000);
        
        turnOpposite();
        currentPosition= destination;
 
        Serial.print("\n");
        Serial.print("Reached destination 1");;
        Serial.print("\n");
      }
      else if(destination== '2')
      {
        Serial.print("\n");
        Serial.print("Goint to destination 2");
        Serial.print("\n");
       
        forward();
        delay(500);
        hault();
        delay(1000);
        
        left();
        delay(1000);
        
        forward();
        delay(1000);
        hault();
        delay(1000);
        
        left();
        delay(1000);
        
        forward();
        delay(500);
        hault();
        delay(1000);
        
        turnOpposite();

        currentPosition= destination;
 
        Serial.print("\n");
        Serial.print("Reached destination 2");;
        Serial.print("\n");
      }
      else if(destination== '4')
      {
        Serial.print("\n");
        Serial.print("Goint to destination 4");
        Serial.print("\n");

        forward();
        delay(980);
        hault();
        delay(1000);
        
        turnOpposite();
        currentPosition= destination;
        
        Serial.print("\n");
        Serial.print("Reached destination 4");;
        Serial.print("\n");
      }
    }
    else if(currentPosition== '4')
    {
      if(destination== '1')
      {
        Serial.print("\n");
        Serial.print("Goint to destination 1");
        Serial.print("\n");

        forward();
        delay(500);
        hault();
        delay(1000);
        
        right();
        delay(1000);
        
        forward();
        delay(1000);
        hault();
        delay(1000);
        
        right();
        delay(1000);
        
        forward();
        delay(500);
        hault();
        delay(1000);
        
        turnOpposite();

        currentPosition= destination;

        Serial.print("\n");
        Serial.print("Reached destination 1");;
        Serial.print("\n");
      }
      else if(destination== '2')
      {
        Serial.print("\n");
        Serial.print("Goint to destination 2");
        Serial.print("\n");

        forward();
        delay(500);
        hault();
        delay(1000);

        right();
        delay(1000);

        forward();
        delay(1000);
        hault();
        delay(1000);

        left();
        delay(1000);

        forward();
        delay(500);
        hault();
        delay(1000);

        turnOpposite();

        currentPosition= destination;

        Serial.print("\n");
        Serial.print("Reached destination 2");;
        Serial.print("\n");
      }
      else if(destination== '3')
      {
        Serial.print("\n");
        Serial.print("Goint to destination 3");
        Serial.print("\n");

        forward();
        delay(980);
        hault();
        delay(1000);
        turnOpposite();
        currentPosition= destination;
        
        Serial.print("\n");
        Serial.print("Reached destination 3");;
        Serial.print("\n");
      }
    }
    
  }//end of while loop
  
}
