############################
library(forecast)
library(dynlm)
library(lmtest)
# nacteni knihoven

############################
data("M1Germany")
head(M1Germany)
  # ekonomicka ctvrtletni data z Nemecka
  # M1 index "financni zasoby"

plot(M1Germany$logm1)
  # casova rada s trendem a sezonnosti, jak pro ni najit optimalni model?

# autokorelacni funkce
par(mfrow=c(2,1))
acf(M1Germany$logm1,na.action =na.pass)
pacf(M1Germany$logm1,na.action =na.pass)
par(mfrow=c(1,1))
  # je videt vysoka autokorelovanost (diky trendu)

# zavislost na ostatnich raddach
par(mfrow=c(3,1))
ccf(M1Germany$logm1,M1Germany$logprice,na.action =na.pass)
ccf(M1Germany$logm1,M1Germany$loggnp,na.action =na.pass)
ccf(M1Germany$logm1,M1Germany$interest,na.action =na.pass)
par(mfrow=c(1,1))
  # je videt vysoka korelovanost s ostatnimi radami
  # s logprice a loggnp s nulovym zpozdenim
  # s interest se zpozdenim 4 roky

# nejprve se podivame na radu jako takovou
plot(decompose(M1Germany$logm1))

m1<-dynlm(M1Germany$logm1~trend(M1Germany$logm1)+season(M1Germany$logm1))
summary(m1)
  # odhady koeficientu trendu i sezonni slozky
acf(m1$residuals)
  # residua jsou korelovana, je treba pridat arima model pro ne

# potrebuji matici "vysvetlujicich promennych tohoto modelu
m1$model[1:20,]
zavisla<-m1$model[,1]
# namisto puvodni rady logm1 pouzivam tu z modelu, kde jsou vynechana chybejici pozorovani
x.reg1<-m1$model[,2:3]
  # regresory
x.reg2<-cbind("trend"=x.reg1[,1],"Q2"=ifelse(x.reg1[,2]=="Q2",1,0),
              "Q3"=ifelse(x.reg1[,2]=="Q3",1,0),"Q4"=ifelse(x.reg1[,2]=="Q4",1,0))
head(x.reg2)
  # vytvoreni "dummy variables" do modelu
x.reg3<-as.matrix(x.reg2)
  # auto.arima potrebuje regresory ve tvaru matice
m2<-auto.arima(zavisla,xreg=x.reg3)
summary(m2)
# vysledny model
acf(m2$residuals)
# mam nekorelovana residua - dobry model
checkresiduals(m2)

# zavislost na ostatnich promennych
m3<-dynlm(M1Germany$logm1~M1Germany$logprice+M1Germany$loggnp+M1Germany$interest)
# zavislost v aktualnim case
summary(m3)
# shrnuti modelu
# ale neni lepsi brat i promenne interest zavislost se zpozdenim?
m4<-dynlm(M1Germany$logm1~M1Germany$logprice+M1Germany$loggnp+L(M1Germany$interest,-4))
# zpozdeni o 4 kroky
summary(m4)
# nevypada to

acf(m3$residuals)
# mam korelovana residua, musim pridat jeste cast arima
# vytvoreni matice regresoru
x.reg<-as.matrix(M1Germany[,2:4])
m5<-auto.arima(M1Germany$logm1,xreg=x.reg)
summary(m5)               
coeftest(m5)
# vsechny koeficienty modelu jsou vyznamne
acf(m5$residuals,na.action = na.pass)
# nekorelovana residua - dobry model
checkresiduals(m5)

# auto arima
m6<-auto.arima(M1Germany$logm1)
summary(m6)
acf(m6$residuals,na.action = na.pass)
# nekorelovana residua - dobry model

# ktery model je nejlepsi?
BIC(m1)
BIC(m2)
BIC(m3)
BIC(m5)
BIC(m6)
# m2 a m5 jsou srovnatelne

plot(M1Germany$logm1)
lines(m2$fitted,col=2)
lines(m5$fitted,col=3)
# oba modely sedi dobre

# predpovedi
# mohu pocitat jen pro model m2, pro model m5 nemam hodnoty regresoru
newd1<-data.frame("trend"=seq(36.25,38,by=0.25),"Q2"=c(0,1,0,0,0,1,0,0),
                "Q3"=c(0,0,1,0,0,0,1,0),"Q4"=c(0,0,0,1,0,0,0,1))
newd2<-as.matrix(newd1)
f2<-forecast(m2,xreg=newd2)
plot(f2)
f2
  # vykresleni a vypsani predpovedi s intervaly spolehlivosti

#############################
### Samostatne

# pouzijte databazi EuStockMarkets a zkuste najit optimalni model pro index DAX
  # databaze burzovnich indexu
head(EuStockMarkets)
DAX <- EuStockMarkets[,1]
SMI <- EuStockMarkets[,2]
CAC <- EuStockMarkets[,3]
FTSE<- EuStockMarkets[,4]

par(mfrow=c(2,1))
acf(EuStockMarkets[,1],na.action =na.pass)
pacf(EuStockMarkets[,1],na.action =na.pass)
par(mfrow=c(1,1))



par(mfrow=c(3,1))
ccf(EuStockMarkets[,1],EuStockMarkets[,2],na.action =na.pass)
ccf(EuStockMarkets[,1],EuStockMarkets[,3],na.action =na.pass)
ccf(EuStockMarkets[,1],EuStockMarkets[,4],na.action =na.pass)
par(mfrow=c(1,1))

plot(decompose(EuStockMarkets[,1]))

m1 <- dynlm(EuStockMarkets[,1] ~ trend(EuStockMarkets[,1]) + season(EuStockMarkets[,1]))
summary(m1)

acf(m1$residuals)

m3<-dynlm(EuStockMarkets[,1]~EuStockMarkets[,2]+EuStockMarkets[,3]+EuStockMarkets[,4])
xreg <- as.matrix(EuStockMarkets[,2:4]) 
model <- auto.arima(EuStockMarkets[,1], xreg = xreg, seasonal = FALSE)

model_2 <- arima(EuStockMarkets[,1], order=c(1,0,0), xreg = xreg)
par(mfrow=c(6,1))
checkresiduals(model$residuals)
checkresiduals(model_2$residuals)
par(mfrow=c(1,1))

plot(EuStockMarkets[,1])
lines(model$fitted,col=2)
lines(model_2$fitted,col='green', lwd=4)


model_2 <- arima(EuStockMarkets[,1], order=c(1,0,0), xreg = xreg)

# Extract the fitted values from model_2
fitted_values <- fitted(model_2)

# Plot the original time series data
plot(EuStockMarkets[,1], type = 'l', col = 'black', lwd = 1, main = 'Original Data')

# Add the fitted values from model_2 to the plot
lines(index(EuStockMarkets[,1]), fitted_values, col = 'green', lwd = 1, lty = 1, 
      main = 'Original Data with Fitted Values')

# Add a legend for clarity
legend('topleft', legend = c('Original Data', 'Fitted Values (ARIMA)'), 
       col = c('black', 'green'), lty = c(1, 1), lwd = c(1, 2))
# sezonnost si vyzkousejte na rade
plot(UKgas)



# nactete data EMG a hledejte optimalni model pro radu iEMG
plot(EMG)
ts(EMG)
plot(ts(EMG))
EMG <- EMG[,2:4]
plot(ts(EMG))
