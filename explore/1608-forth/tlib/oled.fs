\ oled utilities

: show-readings ( vprev vcc tint lux humi pres temp -- )
  hwid hex. ." = "
  dup . ." °cC, "
  1 pick . ." Pa, "
  2 pick . ." %cRH, "
  3 pick . ." lux, "
  4 pick . ." °C, "
  5 pick . ." => "
  6 pick . ." mV "
  ;

: showdigit ( n x -- )
  swap 256 * digits + 64 0 do
    32 0 do
      i $1F xor bit over bit@ if over i + j putpixel then
    loop
    4 +
  loop 2drop ;

: showdot ( x -- )
  64 60 do
    dup 4 + over 1+ do i j putpixel loop
  loop drop ;

: shownum2.2 ( u -- )
  clear
  10 /mod 10 /mod 10 /mod
  -4 showdigit 28 showdigit 60 showdot 64 showdigit 96 showdigit
  display ;

: shownum1.3 ( u -- )
  clear
  10 /mod 10 /mod 10 /mod
  -4 showdigit 28 showdot 32 showdigit 64 showdigit 96 showdigit
  display ;

