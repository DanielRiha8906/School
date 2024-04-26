#############################
### Linearni trend
time<-1971:2000

rada<-Examples1[,1]
rada.ts<-ts(rada,start=1971)
plot(rada.ts)
time<-time(rada.ts)

mod1<-lm(rada.ts~time)
#Ukazuje nám to, že  Yt= -1689 + 0,866*t
summary(mod1)
coef(mod1)
AIC(mod1)
lines(time,fitted(mod1),col=2)

############################
## Kvadraticky trend

rada<-Examples1[,2]
rada.ts<-ts(rada,start=1971)
plot(rada.ts)
time2 <- time*time

mod1<-lm(rada.ts~time+time2)
summary(mod1)
coef(mod1)
AIC(mod1)
lines(time,fitted(mod1),col=2)

mod1<-lm(rada.ts~time)
summary(mod1)
coef(mod1)
AIC(mod1)
lines(time,fitted(mod1),col=3)

############################
## Exponencialni trend

rada<-Examples1[,3]
rada.ts<-ts(rada,start=1971)
plot(rada.ts)

ln.rada.ts<-log(rada.ts)
#plot(ln.rada.ts)
mod1<-lm(ln.rada.ts~time)
summary(mod1)
coef(mod1)
exp(coef(mod1))
#Kvůli logaritmování nejde použít akaike na tento trend -> take it as a fact
AIC(mod1)
lines(time,exp(fitted(mod1)),col=2)
#Kvadratické odhadnutí trendu
mod1<-lm(rada.ts~time+time2)
summary(mod1)
coef(mod1)
AIC(mod1)
lines(time,fitted(mod1),col=3)

#Lineární odhadnutí trendu
mod1<-lm(rada.ts~time)
summary(mod1)
coef(mod1)
AIC(mod1)
lines(time,fitted(mod1),col=4)

##############################
## Logisticky trend
x<-1:30

rada<-Examples1[,4]
rada.ts<-ts(rada,start=1971)
plot(rada.ts)
-(log(120))/log(0.7)

mod1<-nls(rada.ts ~ SSlogis(time, Asym, xmid, scal))
mod1<-nls(rada.ts ~ SSlogis(x, Asym, xmid, scal))
summary(mod1)
coef(mod1)
AIC(mod1)
plot(rada.ts)
lines(time, fitted(mod1), col=2)

#Velmi těžko se dá poznat, zdali je to logistický, nebo gompertzova křivak -> 
#
mod1<-nls(rada.ts ~ SSgompertz(time, Asym, b2, b3))
mod1<-nls(rada.ts ~ SSgompertz(x, Asym, b2, b3))
summary(mod1)
coef(mod1)
AIC(mod1)
plot(rada.ts)
lines(time, fitted(mod1), col=3)

##############################
## Gompertzova krivka

rada<-Examples[,5]
rada.ts<-ts(rada,start=1971)
plot(rada.ts)
-(log(13.2))/log(0.8)


mod1<-nls(rada.ts ~ SSgompertz(time, Asym, b2, b3))
mod1<-nls(rada.ts ~ SSgompertz(x, Asym, b2, b3))
summary(mod1)
coef(mod1)
AIC(mod1)
plot(rada.ts)
lines(time, fitted(mod1), col=2)

mod1<-nls(rada.ts ~ SSlogis(time, Asym, xmid, scal))
mod1<-nls(rada.ts ~ SSlogis(x, Asym, xmid, scal))
summary(mod1)
coef(mod1)
AIC(mod1)
##################################################################

rada<- Examples1[,11]
rada.ts<-ts(rada,start=1971)
plot(rada.ts)

mod1<-lm(rada.ts~time+time2)
summary(mod1)
coef(mod1)
AIC(mod1)
lines(time,fitted(mod1),col=2)

