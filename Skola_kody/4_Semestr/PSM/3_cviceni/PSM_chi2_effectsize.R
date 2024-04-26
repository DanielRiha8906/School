###################
###Chi-kvadrat test
data(mtcars)

##Souvisi spolu pocet valcu a typ prevodovky?
kat1<-mtcars$cyl
kat2<-mtcars$am
table(kat1,kat2)
#Umime i obrazek?
plot(as.factor(kat1)~as.factor(kat2),col=2:4,main="souvislost poctu valcu a typu prevodovky")

#testujeme H0: pocet valcu a typ prevodovky spolu nesouvisi
#H1: pocet valcu a typ prevodovky spolu souvisi
chisq.test(kat1,kat2)
#p-hodnota 0.01265 < alfa 0.05 => zamitame H0
#Pocet valcu a typ prevodovky spolu souvisi.
#Ale pozor(!) warning nam rika, ze nejsou splneny predpoklady pouziti chi-kvadrat testu
chisq.test(kat1,kat2)$ex
#tri ocekavana cetnost je mensi nez 5

#Pro ty same hypotezy pouzijeme Fisheruv exaktni test
fisher.test(kat1,kat2)
#p-hodnota 0.009105 < alfa 0.05 => zamitame H0
#Pocet valcu a typ prevodovky spolu souvisi.

##Souvisi spolu typ motoru a typ prevodovky (promenne vs a am)
#Jiny vystup pro Fisheruv exaktni test
kat1<-mtcars$vs
kat2<-mtcars$am
table(kat1,kat2)
plot(as.factor(kat1)~as.factor(kat2),col=2:4,main="souvislost poctu valcu a typu prevodovky")
chisq.test(kat1,kat2)
# p-value = 0.5555 => nezamítáme H0 tudíž nezávisí

###################
###Nacteni dat Stulong.RData
##data z velke studie, ktera u muzu stredniho veku merila riziko srdecni choroby

names(Stulong)<-c("ID","vyska","vaha","syst1","syst2","chlst","vino","cukr",
                  "bmi","vek","KOURrisk","Skupina","VekK")

###################
###Vecna vyznamnost
library(effectsize)
library(DescTools)

##Je vyznamny rozdil ve vysce mezi starsimi a mladsimi muzi? (promenne vyska, VekK)
ciselna<-Stulong$vyska
kategoricka<-Stulong$VekK

par(mfrow=c(1,2))
tapply(ciselna,kategoricka,PlotQQ)
par(mfrow=c(1,1))
tapply(ciselna,kategoricka,hist)
tapply(ciselna,kategoricka,shapiro.test)
#jsou odchylky od normality skutecne vyznamne?

var.test(ciselna~kategoricka)

t.test(ciselna~kategoricka,var.ex=T)
plot(ciselna~kategoricka)
#Je rozdil ve vyskach skutecne vyznamny?

###Statistiky vecne vyznamnosti
cohens_d(ciselna~kategoricka)
#Cohenovo d
interpret_cohens_d(cohens_d(ciselna~kategoricka))

hedges_g(ciselna~kategoricka)
#Hedgesovo g
interpret_hedges_g(hedges_g(ciselna~kategoricka))

glass_delta(ciselna~kategoricka)
#Glassovo delta
interpret_glass_delta(glass_delta(ciselna~kategoricka))

eta_squared(aov(ciselna~kategoricka))
#Fisherovo eta
(A<-anova(aov(ciselna~kategoricka)))
A[,2]
A[1,2]/(sum(A[,2]))
    
omega_squared(aov(ciselna~kategoricka))
#Haysova omega
(A[1,2]-A[2,3])/(sum(A[,2])+A[2,3])

epsilon_squared(aov(ciselna~kategoricka))
#dalsi charakteristika

###################
## Souvisi spolu diagnosticka Skupina a vek muzu (promenne Skupina, VekK)
kat1<-Stulong$Skupina
kat2<-Stulong$VekK

(tab<-table(kat1,kat2))
plot(as.factor(kat1)~as.factor(kat2),col=2:5)
chisq.test(kat1,kat2)
#je rozdil ve skupinach skutecne podstatny?


chisq_to_cramers_v(chisq.test(tab)$statistic,
             n = sum(tab),
             nrow = nrow(tab),
             ncol = ncol(tab)
)
#Cramerovo V
sqrt(chisq.test(tab)$statistic/(sum(tab)*(ncol(tab)-1)))

##Souvisi spolu konzumace vina a vek muzu (promenne vino, VekK)
kat1<-Stulong$vino
kat2<-Stulong$VekK
(tab<-table(kat1,kat2))
plot(as.factor(kat1)~as.factor(kat2),col=2:5)
chisq.test(kat1,kat2)  

chisq_to_phi(chisq.test(tab)$statistic,
             n = sum(tab),
             nrow = nrow(tab),
             ncol = ncol(tab)
)
#Cramerovo phi
sqrt(chisq.test(tab)$statistic/sum(tab))

###################
##Souvisi spolu vaha a hladina cholesterolu?
cislo1<- Stulong$syst1
kategorie<- as.factor(Stulong$vino)
plot(cislo1~kategorie)

par(mforw=c(1,2))
tapply(cislo,kategorie)
par(mfrow=c(1,1))
tapply(cislo1,kategorie,PlotQQ)

tapply(cislo1,kategorie,shapiro.test)

var.test(cislo1~kategorie)

t.test(cislo1~kategorie,var.ex=T)
plot(cislo1~kategorie)
#0.001 p hodnota
cohens_d(cislo1~kategorie)

#závislost cholesterolu na kouření
cislo1<-Stulong$chlst
kategorie<-as.factor(Stulong$KOURrisk)
boxplot(cislo1~kategorie)

par(mforw=c(1,2))
tapply(cislo,kategorie)
par(mfrow=c(1,1))
tapply(cislo1,kategorie,PlotQQ)


var.test(cislo1~kategorie)
#p-value 0.21, nezamítám H0, stejná variabilita

t.test(cislo1~kategorie)
wilcox.test(cislo1~kategorie)

cohens_d(cislo1~kategorie)
#závislost váha na skupině
cislo1<-Stulong$vaha
kategorie<-as.factor(Stulong$Skupina)
boxplot(cislo1~kategorie)

result_anova <- anova(aov(cislo1~kategorie))
print(result_anova)
tabb<-table(cislo1,kategorie)
fisher.test(tabb)
#cukr na skupině
#systolický tlak a váha


