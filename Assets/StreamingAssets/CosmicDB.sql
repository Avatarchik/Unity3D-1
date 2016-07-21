DROP TABLE IF EXISTS "garbageTable";
CREATE TABLE "garbageTable" ("pID" VARCHAR PRIMARY KEY  NOT NULL , "name" VARCHAR, "size" INTEGER, "color" INTEGER, "locationX" FLOAT, "locationY" FLOAT, "locationZ" FLOAT, "mat" INTEGER);
DROP TABLE IF EXISTS "garbageTableTest";
CREATE TABLE "garbageTableTest" ("name" VARCHAR,"size" INTEGER,"color" INTEGER,"locationX" FLOAT,"locationY" FLOAT,"locationZ" FLOAT,"mat" INTEGER);
DROP TABLE IF EXISTS "managePlanetTable";
CREATE TABLE "managePlanetTable" 
 ("name" VARCHAR,"size" INTEGER,"color" INTEGER,"mat" INTEGER,"mFood" INTEGER, "mTitanium" INTEGER,
  "locationX" FLOAT,"locationY" FLOAT,"locationZ" FLOAT,
 "le_persec" INTEGER,
 "position_house" BOOL,
 "state" INTEGER,
 "User" BOOL,"neighbor" INTEGER,
 "lFood" INTEGER,"lTitanium" INTEGER,
 "planetTouchT" DATETIME,"titaniumTouchT" DATETIME,"treeTouchT" DATETIME,
 "breaktime" DATETIME DEFAULT (0) ,
 "tree1" INTEGER DEFAULT (0) ,"tree2" INTEGER DEFAULT (0) ,"tree3" INTEGER DEFAULT (0) ,
 "tree4" INTEGER DEFAULT (0) ,"tree5" INTEGER DEFAULT (0) ,"tree6" INTEGER DEFAULT (0) );
INSERT INTO "managePlanetTable" VALUES('잘생긴 초록색 쌍둥이',1,5,2,183,438,3.5,0,14.25353,1,1,1,1,0,183,438,NULL,NULL,NULL,0,3,0,0,0,0,0);
INSERT INTO "managePlanetTable" VALUES('기발한 보라색 쌍둥이',2,4,2,457,734,3.5,0,11.40659,2,0,1,0,0,457,734,NULL,NULL,NULL,0,0,0,0,0,0,0);
INSERT INTO "managePlanetTable" VALUES('겸손한 노란색 쌍둥이',3,3,2,1403,1441,0,3.5,14.25211,3,0,1,0,0,1403,1441,NULL,NULL,NULL,0,0,0,0,0,0,0);
INSERT INTO "managePlanetTable" VALUES('늠름한 초록색 쌍둥이',2,5,2,658,666,-3.5,0,14.25861,2,0,1,0,0,658,666,NULL,NULL,NULL,0,0,0,0,0,0,0);
DROP TABLE IF EXISTS "managePlanetTableTest";
CREATE TABLE "managePlanetTableTest" ("name" VARCHAR,"size" INTEGER,"color" INTEGER,"mFood" INTEGER,"le_persec" INTEGER,"locationX" FLOAT,"locationY" FLOAT,"locationZ" FLOAT,"mat" INTEGER,"state" INTEGER,"lFood" INTEGER,"lTitanium" INTEGER,"position_house" BOOL,"tree" INTEGER,"User" BOOL,"neighbor" INTEGER,"planetTouchT" DATETIME,"titaniumTouchT" DATETIME,"treeTouchT" DATETIME,"breaktime" DATETIME DEFAULT (0) ,"mTitanium" INTEGER);
INSERT INTO "managePlanetTableTest" VALUES('파란별',1,5,5000,1,0,0,0,1,1,5000,5000,0,0,1,0,NULL,NULL,NULL,0,5000);
DROP TABLE IF EXISTS "userTable";
CREATE TABLE "userTable" ("cPlanet" INTEGER PRIMARY KEY  NOT NULL  DEFAULT (null) ,"cFood" INTEGER,"cTitanium" INTEGER,"cRE" INTEGER,"cYE" INTEGER,"cBE" INTEGER,"cOE" INTEGER,"cGE" INTEGER,"cVE" INTEGER,"cPE" INTEGER,"shipNum" INTEGER DEFAULT (1) );
INSERT INTO "userTable" VALUES(1,125,7501,200,289,389,201,312,401,349,2);
DROP TABLE IF EXISTS "userTableTest";
CREATE TABLE "userTableTest" ("cPlanet" INTEGER PRIMARY KEY  NOT NULL  DEFAULT (null) ,"cFood" INTEGER,"cTitanium" INTEGER,"cRE" INTEGER,"cYE" INTEGER,"cBE" INTEGER,"cOE" INTEGER,"cGE" INTEGER,"cVE" INTEGER,"cPE" INTEGER,"shipNum" INTEGER DEFAULT (1) );
INSERT INTO "userTableTest" VALUES(1,125,7501,200,289,389,201,312,401,349,2);
DROP TABLE IF EXISTS "zodiacTable";
CREATE TABLE "zodiacTable" ("zID" VARCHAR, "zodiac" VARCHAR, "name" VARCHAR, "locationX" FLOAT, "locationY" FLOAT, "locationZ" FLOAT, "open" BOOL DEFAULT false, "find" BOOL DEFAULT false, "needPE" INTEGER, "nowPE" INTEGER DEFAULT 0, "active" BOOL DEFAULT false);
INSERT INTO "zodiacTable" VALUES('Aqua_1','Aquarius','물병자리 α',95.45624,59.22803,-94.25877,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Aqua_2','Aquarius','물병자리 β',84.3187,50.98542,-107.4906,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Aqua_3','Aquarius','물병자리 ε',86.51397,33.76286,-115.3511,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Aqua_4','Aquarius','물병자리 γ',93.15521,78.47528,-85.38417,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Aqua_5','Aquarius','물병자리 δ',67.20883,104.533,-78.40474,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Aqua_6','Aquarius','물병자리 ζ',104.6873,75.84821,-71.48267,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Pis_1','Pisces','물고기 τ
',125.8203,-52.42453,-55.93538,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Pis_2','Pisces','물고기 η
',109.1752,-81.03933,-56.64024,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Pis_3','Pisces','물고기 α
',81.88113,-105.1532,-64.51326,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Pis_4','Pisces','물고기 ω
',115.5208,-92.74446,-8.117889,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Pis_5','Pisces','물고기 γ
',118.9684,-86.19568,14.49984,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Ari_1','Aries
','물고기 γ
양 α',138.0007,22.02558,-43.38361,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Ari_2','Aries
','양 β',141.1194,18.56916,-31.85226,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Ari_3','Aries
','양 γ',145.3995,10.18031,-26.58704,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Ari_4','Aries
','양 c',134.7,-6.692806,-61.78034,0,0,3500,0,0);
INSERT INTO "zodiacTable" VALUES('Tau_1','Taurus','황소 β',0.09102631,39.35595,-139.5479,0,0,20000,0,0);
INSERT INTO "zodiacTable" VALUES('Tau_2','Taurus','알키오네 A',49.76662,-19.50167,-133.992,0,0,20000,0,0);
INSERT INTO "zodiacTable" VALUES('Tau_3','Taurus','알데바란',4.840668,-3.33013,-143.3997,0,0,20000,0,0);
INSERT INTO "zodiacTable" VALUES('Tau_4','Taurus','황소 Z',-18.15458,33.69873,-141.9869,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Tau_5','Taurus','황소 μ',9.695553,-35.83193,-142.7573,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Tau_6','Taurus','황소 ο',43.87536,-59.56677,-127.92,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Gem_1','Gemini
','카스토르 α',39.9869,-45.8391,135.7425,0,0,20000,0,0);
INSERT INTO "zodiacTable" VALUES('Gem_2','Gemini
','쌍둥이 μ',-61.26863,-2.229683,133.6458,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Gem_3','Gemini
','폴룩스',34.63615,-83.98577,116.01,0,0,20000,0,0);
INSERT INTO "zodiacTable" VALUES('Gem_4','Gemini
','쌍둥이 δ',-45.79444,-78.40003,116.5651,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Gem_5','Gemini
','쌍둥이 γ',-92.27318,-41.38876,108.7566,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Can_1','Cancer
','게자리 ι',85.05074,120.3201,-17.38228,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Can_2','Cancer
','게 η',81.44978,123.0851,13.40921,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Can_3','Cancer
','게 δ',94.85455,113.9595,14.98248,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Can_4','Cancer
','게 α',108.5659,97.63843,27.09536,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Can_5','Cancer
','게 β',79.68048,114.9706,52.00037,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Leo_1','Leo','데네볼라',37.59104,21.67838,141.3672,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Leo_2','Leo','사자 δ',48.63123,51.90606,129.9246,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Leo_3','Leo','사자 γ',40.9482,86.14223,111.2278,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Leo_4','Leo','레굴루스',15.61906,92.47849,109.5357,0,0,20000,0,0);
INSERT INTO "zodiacTable" VALUES('Vir_1','Virgo
','처녀 ε',-44.68617,129.0779,-53.72023,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Vir_2','Virgo
','처녀 ζ',-30.62435,142.873,-18.56446,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Vir_3','Virgo
','처녀 μ',-10.04597,146.8916,13.73393,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Vir_4','Virgo
','스피카',-43.63457,137.4329,18.64918,0,0,20000,0,0);
INSERT INTO "zodiacTable" VALUES('Vir_5','Virgo
','처녀 β',-83.47186,119.9398,-17.57651,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Lib_1','Libra
','천칭 β',-114.7079,8.9377,-89.17587,0,0,20000,0,0);
INSERT INTO "zodiacTable" VALUES('Lib_2','Libra
','천칭 γ',-135.4559,11.51417,-53.36755,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Lib_3','Libra
','천칭 θ',-144.7992,13.73885,-23.92107,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Lib_4','Libra
','천칭 α2',-110.3139,-26.10806,-94.89411,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Lib_5','Libra
','천칭 σ',-122.8959,-59.61082,-56.04865,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Sco_1','Scorpius
','전갈 β',-1.193334,-143.6193,-36.49713,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Sco_2','Scorpius
','전갈 δ',-4.82719,-144.9903,-25.84548,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Sco_3','Scorpius
','안타레스',-20.25397,-141.8781,-21.20221,0,0,20000,0,0);
INSERT INTO "zodiacTable" VALUES('Sco_4','Scorpius
','전갈 ε',-29.21428,-145.0695,3.531686,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Sco_5','Scorpius
','전갈 θ',-35.33252,-140.7293,29.14709,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Sco_6','Scorpius
','전갈 λ',-39.49166,-141.2363,11.64473,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Sag_1','Sagittarius
','궁수  ε',126.585,14.0534,74.05944,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Sag_2','Sagittarius
','궁수 δ',134.2032,6.209394,63.19669,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Sag_3','Sagittarius
','궁수 σ',128.5274,-20.26199,70.89449,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Sag_4','Sagittarius
','궁수 ζ',121.1519,-12.63404,84.65402,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Sag_5','Sagittarius
','궁수 α',103.0606,9.384216,106.5307,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Sag_6','Sagittarius
','궁수 β',97.38421,21.49911,108.7422,0,0,7000,0,0);
INSERT INTO "zodiacTable" VALUES('Cap_1','Capricornus
','염소 α',-124.882,76.356,12.90719,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Cap_2','Capricornus
','염소 β',-127.5071,69.07703,23.82543,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Cap_3','Capricornus
','염소 ω',-132.1735,25.02634,58.74035,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Cap_4','Capricornus
','염소 ζ',-123.4426,42.10281,67.09779,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Cap_5','Capricornus
','염소 δ',-101.0261,62.54784,88.17496,0,0,12000,0,0);
INSERT INTO "zodiacTable" VALUES('Cap_6','Capricornus
','염소 θ',-118.3932,68.67901,54.41248,0,0,12000,0,0);
DROP TABLE IF EXISTS "zodiacTableTest";
CREATE TABLE "zodiacTableTest" ("zID" VARCHAR, "zodiac" VARCHAR, "name" VARCHAR, "locationX" FLOAT, "locationY" FLOAT, "locationZ" FLOAT, "open" BOOL DEFAULT false, "find" BOOL DEFAULT false, "needPE" INTEGER, "nowPE" INTEGER DEFAULT 0, "active" BOOL DEFAULT false);
INSERT INTO "zodiacTableTest" VALUES('Aqua_1','Aquarius','물병자리 α',95.45624,59.22803,-94.25877,0,0,12000,10000,0);
INSERT INTO "zodiacTableTest" VALUES('Aqua_2','Aquarius','물병자리 β',84.3187,50.98542,-107.4906,0,0,12000,11888,0);
INSERT INTO "zodiacTableTest" VALUES('Aqua_3','Aquarius','물병자리 ε',86.51397,33.76286,-115.3511,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Aqua_4','Aquarius','물병자리 γ',93.15521,78.47528,-85.38417,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Aqua_5','Aquarius','물병자리 δ',67.20883,104.533,-78.40474,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Aqua_6','Aquarius','물병자리 ζ',104.6873,75.84821,-71.48267,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Pis_1','Pisces','물고기 τ
',125.8203,-52.42453,-55.93538,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Pis_2','Pisces','물고기 η
',109.1752,-81.03933,-56.64024,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Pis_3','Pisces','물고기 α
',81.88113,-105.1532,-64.51326,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Pis_4','Pisces','물고기 ω
',115.5208,-92.74446,-8.117889,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Pis_5','Pisces','물고기 γ
',118.9684,-86.19568,14.49984,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Ari_1','Aries
','물고기 γ
양 α',138.0007,22.02558,-43.38361,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Ari_2','Aries
','양 β',141.1194,18.56916,-31.85226,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Ari_3','Aries
','양 γ',145.3995,10.18031,-26.58704,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Ari_4','Aries
','양 c',134.7,-6.692806,-61.78034,0,0,3500,0,0);
INSERT INTO "zodiacTableTest" VALUES('Tau_1','Taurus','황소 β',0.09102631,39.35595,-139.5479,0,0,20000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Tau_2','Taurus','알키오네 A',49.76662,-19.50167,-133.992,0,0,20000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Tau_3','Taurus','알데바란',4.840668,-3.33013,-143.3997,0,0,20000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Tau_4','Taurus','황소 Z',-18.15458,33.69873,-141.9869,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Tau_5','Taurus','황소 μ',9.695553,-35.83193,-142.7573,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Tau_6','Taurus','황소 ο',43.87536,-59.56677,-127.92,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Gem_1','Gemini
','카스토르 α',39.9869,-45.8391,135.7425,0,0,20000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Gem_2','Gemini
','쌍둥이 μ',-61.26863,-2.229683,133.6458,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Gem_3','Gemini
','폴룩스',34.63615,-83.98577,116.01,0,0,20000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Gem_4','Gemini
','쌍둥이 δ',-45.79444,-78.40003,116.5651,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Gem_5','Gemini
','쌍둥이 γ',-92.27318,-41.38876,108.7566,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Can_1','Cancer
','게자리 ι',85.05074,120.3201,-17.38228,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Can_2','Cancer
','게 η',81.44978,123.0851,13.40921,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Can_3','Cancer
','게 δ',94.85455,113.9595,14.98248,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Can_4','Cancer
','게 α',108.5659,97.63843,27.09536,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Can_5','Cancer
','게 β',79.68048,114.9706,52.00037,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Leo_1','Leo','데네볼라',37.59104,21.67838,141.3672,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Leo_2','Leo','사자 δ',48.63123,51.90606,129.9246,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Leo_3','Leo','사자 γ',40.9482,86.14223,111.2278,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Leo_4','Leo','레굴루스',15.61906,92.47849,109.5357,0,0,20000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Vir_1','Virgo
','처녀 ε',-44.68617,129.0779,-53.72023,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Vir_2','Virgo
','처녀 ζ',-30.62435,142.873,-18.56446,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Vir_3','Virgo
','처녀 μ',-10.04597,146.8916,13.73393,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Vir_4','Virgo
','스피카',-43.63457,137.4329,18.64918,0,0,20000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Vir_5','Virgo
','처녀 β',-83.47186,119.9398,-17.57651,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Lib_1','Libra
','천칭 β',-114.7079,8.9377,-89.17587,0,0,20000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Lib_2','Libra
','천칭 γ',-135.4559,11.51417,-53.36755,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Lib_3','Libra
','천칭 θ',-144.7992,13.73885,-23.92107,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Lib_4','Libra
','천칭 α2',-110.3139,-26.10806,-94.89411,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Lib_5','Libra
','천칭 σ',-122.8959,-59.61082,-56.04865,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Sco_1','Scorpius
','전갈 β',-1.193334,-143.6193,-36.49713,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Sco_2','Scorpius
','전갈 δ',-4.82719,-144.9903,-25.84548,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Sco_3','Scorpius
','안타레스',-20.25397,-141.8781,-21.20221,0,0,20000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Sco_4','Scorpius
','전갈 ε',-29.21428,-145.0695,3.531686,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Sco_5','Scorpius
','전갈 θ',-35.33252,-140.7293,29.14709,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Sco_6','Scorpius
','전갈 λ',-39.49166,-141.2363,11.64473,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Sag_1','Sagittarius
','궁수  ε',126.585,14.0534,74.05944,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Sag_2','Sagittarius
','궁수 δ',134.2032,6.209394,63.19669,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Sag_3','Sagittarius
','궁수 σ',128.5274,-20.26199,70.89449,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Sag_4','Sagittarius
','궁수 ζ',121.1519,-12.63404,84.65402,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Sag_5','Sagittarius
','궁수 α',103.0606,9.384216,106.5307,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Sag_6','Sagittarius
','궁수 β',97.38421,21.49911,108.7422,0,0,7000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Cap_1','Capricornus
','염소 α',-124.882,76.356,12.90719,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Cap_2','Capricornus
','염소 β',-127.5071,69.07703,23.82543,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Cap_3','Capricornus
','염소 ω',-132.1735,25.02634,58.74035,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Cap_4','Capricornus
','염소 ζ',-123.4426,42.10281,67.09779,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Cap_5','Capricornus
','염소 δ',-101.0261,62.54784,88.17496,0,0,12000,0,0);
INSERT INTO "zodiacTableTest" VALUES('Cap_6','Capricornus
','염소 θ',-118.3932,68.67901,54.41248,0,0,12000,0,0);
