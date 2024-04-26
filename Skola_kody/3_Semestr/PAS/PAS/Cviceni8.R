#############################
### Priklady na pravdepodobnost

### Diskretni rozdeleni
## Binomicke rozdeleni: n - pocet pokusu, p - pst uspechu
#   pocet uspechu v n-pokusech
# pbinom(k,n,p) - distribucni funkce
# dbinom(k,n,p) - pravdepodobnostni funcke
# stredni hodnota n*p
# rozptyl n*p*(1-p)

## Hypergeometricke rozdeleni: w - pocet bilych kouli v osudi, b - pocet cernych kouli v osudi
#   n - pocet kouli tazenych z osudi
#   pocet bilych kouli mezi n tazenymi
# phyper(k,w,b,n) - distribucni funkce
# dhyper(k,w,b,n) - pravdepodobnostni funcke
# stredni hodnota n*w/(w+b)
# rozptyl (n*w/(w+b))*(1-w/(w+b))*((w+b-n)/(w+b-1))

## Geometricke rozdeleni: p - pravdepodobnost uspechu
# cekani na prvni uspech, do prikazu se zadava pocet neuspechu pred prvnim uspechem
# pgeom(k,p) - distribucni funkce
# dgeom(k,p) - pravdepodobnostni funcke
# stredni hodnota (1-p)/p
# rozptyl (1-p)/p^2


## Poissonovo rozdeleni: lambda - stredni hodnota
# pocet udalosti
# ppois(k,lambda) - distribucni funkce
# dpois(k,lambda) - pravdepodobnostni funcke
# stredni hodnota lambda
# rozptyl lambda

## Negativni binomicke rozdeleni: n - pocet uspechu, p - pst uspechu
# pnbinom(k,n,p) - distribucni funkce
# dnbinom(k,n,p) - pravdepodobnostni funcke

#################################
### Spojita rozdeleni
## Normalni rozdeleni: mu - stredni hodnota, sigma - smerodatna odchylka
# pnorm(x,mu,sigma) - distribucni funkce

# hustota - vyska dospelych muzu
curve(dnorm(x,180,7),from=150,to=210, main="Hustota N(180, 49)",col="red",ylab="Hustota")
# distribucni funkce - vyska dospelych muzu
curve(pnorm(x,180,7),from=150,to=210, main="Distribucni funkce N(180, 49)",col="purple",ylab="Hustota")

## Lognormalni rozdeleni: mu , sigma (velicina ln(X) ~ N(mu, sigma^2))
# plnorm(x,mu,sigma) - distribucni funkce
# qlnorm(x,mu,sigma) - kvantilova funkce
# stredni hodnota exp(mu+sigma^2/2)
# rozptyl (exp(sigma^2)+2)*exp(2*mu+sigma^2)

## Exponencialni rozdeleni: int - intenzita
# pexp(x,int) - distribucni funkce
# qexp(x,int) - kvantilova funkce
# distribucni funkce P(X <= t) = 1 - exp(-int*t)
# stredni hodnota 1/int
# rozptyl 1/int^2

#################################
### Centralni limitni veta
## Rozdeleni souctu nezavislych, stejne rozdelenych nahodnych velicina
#  konverguje k normalnimu pro pocet techto velicin rostouci nade vsechny meze.
#
library(TeachingDemos)
clt.examp(1)
clt.examp(2)
clt.examp(5)
clt.examp(10)
clt.examp(50)

#Nechť náhodná proměnná jest x N(2,5) - směrodatná rozptylka a rozptyl
# Stanovte kvartily  této proměnné a lvartilové rozpětí, to interpretujte.
# qnorm(x,mu,sigma) - kvantilova funkce
#hledáme první, druhý a třetí kvartil - 
qnorm(c(1/4,1/2,3/4),2,sqrt(5))
qnorm(3/4,2,sqrt(5)) - qnorm(1/4,2,sqrt(5))
#0,4951, 2.0000, 3.5082 rozpětí -> 3,5082 - 0,4951 -> 3.01641

# Pojištění 
qlnorm(1/2, 6, sqrt(2))
qlnorm(0.95,6,sqrt(2))

# N (2,9)
1-pnorm(0.5,2,3) # větší jak 0.5
1-pnorm(-1.2,2,3) #větší jak 1,2
pnorm(-1.2,2,3) # menší jak 1,2
pnorm(1,2,3) - pnorm(-0.5,2,3) # mezi -0,5 a 1
# X(20,25) -> U = X-u/sd(x) -> X-20/5  U má střední hodnotu 20 a směrodatnou odchylku 1
(1.645*5)+20
#,ám P(u <1,645)=0,95 mám z toho najít x, kde platí - P(X<x)=0,95


#Exponenciální - střední doba = 1/lambda
# P(x<=1000) = 0.1 -> <= znamená distribuční fce pexp -> 1-exp(-int*t)
int = -log(0.9)/1000
1/int
#1/int jest střední hodnota
1/(int*int)
curve(dexp(x,int),from=0,to=100000, main="Hustota exp(0,000105)", col='red')
#P(X>365)=1-dexp(365,int)
1-pexp(365,int)
#P(200<x<700)
pexp(700,int) - pexp(200,int)
#2000 dní střední hodnota
#P(>=3000) tím pádem 1-pexp(3000,1/2000)
int <- 1/2000
1-pexp(3000,1/2000)
#Nebude fungovat dýl, než střední hodnota
pexp(2000,1/2000)
qexp(0.05,1/2000)
curve(dexp(x,int),from=0,to=100000, main="Hustota exp(0,000105)", col='red')


#Centrální nilmitní věta 