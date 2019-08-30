-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: course
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `registrar`
--

DROP TABLE IF EXISTS `registrar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `registrar` (
  `id` int(2) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `surname` varchar(45) DEFAULT NULL,
  `gender` varchar(45) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `image` longblob,
  `email` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registrar`
--

LOCK TABLES `registrar` WRITE;
/*!40000 ALTER TABLE `registrar` DISABLE KEYS */;
INSERT INTO `registrar` VALUES (4,'Ezgi','Ä°nce','Female',33,_binary 'ÿ\Øÿ\à\0JFIF\0\0\0\0\0\0ÿ\Û\0„\0	( \Z%!1!%)+...383,7(-.+\n\n\n\r\Z-% &----------//-+------------------------------------ÿÀ\0\n\0¾\"\0ÿ\Ä\0\0\0\0\0\0\0\0\0\0\0\0\0ÿ\Ä\0:\0\0\0\0!1AQ\"aq‘¡±Áð2B\Ñ#Rbr\áñ3‚’²ÿ\Ä\0\Z\0\0\0\0\0\0\0\0\0\0\0\0\0ÿ\Ä\0(\0\0\0\0\0\0\0\0!1A\"Qq#2¡±ÿ\Ú\0\0\0?\0…ø(­•\à)XIE,(ù¯2£AJ‰U\Þj!£uZp\Ô´.€‹è°µ\ru|\ëò\îi·\îi‰E\ìox£(9c$ŠRC½•\Î\ÙFhßŽ©B\Ñò—\×#+–\×ÁK÷\Ï\0ªñY«\Ô\'({“è°½À\Íy­\0`!lyŽ°\ÜQÌ‚>#\è™úrk¢¶4\Û\Ýñ	•Eõx+…Xea\Ö.\çG‘Dk_’wE´û‡F\nP§¾\èÍ\ç	T–\Ê	\ê|L¤\ÝG\Ó)¢\æð8D w\Ì˜+n	;Dhçš½$¡BJ?\ÚwzT\×Søf«S…¯…f !h}@‡.\ËLª»°ª¤õ\ë\ÚJù”HZIQcÕ¹\Â\ÝN\í­A*\\FÊ“tO\"\áe]45œ!zµ\ç\åm\É\nùrŸM\Ùmž9’p‹iVfee°¥\Î‹@…2=R$b°§N¹P¥_\n‹«¦1¥\ïp\0d\ÉK¨\Û[X\è³U\Ô\Z\Æ\ËIq\r`\âsAÐ«N•Fÿ\0Wˆ‡~\Ó8\ÜO\ç°{žÒ²ÖŸun\Ñ\Ädñ8\È\rŸ\Ôã»¼‡óž–-¾\Â(\×aª\Ô5\n€¼´QaÛ‰\Ð\Z?\Ñ9>n\è†Ö´¨\Ïugùœ±\ÇË€’ƒ\Ò\ÖkV£gÇ‡ôµ\Ä\ÃC)þ‘Ÿt:³®ª\ÅK‹·ŠŽ\Ëi´¹\Õ8yE&\ró8M¤\Ëmz*kX\Ù\â\ròñ?r\ÚW“¤\ã\æ?W°\Øú}T4û‡Áp\Û\É\Ç\Âñ\Ð\Ó\éô±\ÝÐŽ\ï„\æ\0ª\Ì\Ì7Ÿ¯Ç’Ä¡\Ú\'iµYPq0\É\æ‚=G$UöÍºZ·\Ô8\ÂZ\á¸p8sŒ\'*þFü#\æË…E\Ú(Š÷:k\ÙûŠ\È\ËÆŒe3kŒ\á9›j5\åÄƒ\ÍTa\ÈU\Ñv±rÜ™KÌ©•õÄ’£Jš~Q‰†Í´U\í¡*š\ÊudZ5[Z\áx\êBT™[S¥h\ç?É«¤j· ^Q&X\ÃT´j@	[/+€\ê\Ø\ÌNè†Ÿ…¼ÀòLvD@+J™ilµ˜l£LL-v\ÖÀ\å}L´8—ró<’™#³i†°\Èk‰p\Ü œR¥\Ýr¥7ÇŽF\0?p\'2}°¥«j\\4\èùU…7x\Úö’\âdñ~O¼¦0\âŠù\ãA›ú´\Ý\Â6\ç;\ÖIK7v.¨ò\í›?!€Á7i\Zy\æ¶\éL\Òþ§‚¬\\»9\çr@­.<§`zÂ•›n\éK™R£¿W\á\'ýN+¢³HdŒ+j\é\í\è«ê¿±¿ ŽqSW¹h‡ƒVF\Ï3…\ÇuÚƒšg€Ž­99O?\ÈOÚžŽ\Ò6J\Z¾ŸÃ»I\\¼\Ö\á8·\Ð<˜¥i–>¹{dfGN}\ÚD\ïRÑµ—µå“¸\ÆpL` V—…€6K›}þK}ZaÇ‰¢ƒ¼`\äg\áòö¹ASLvº©V¦	C«\Ú9»„Å ;¼ðœ¸|\Â2\Ýˆ™o\Å+|]P	E£›<X0œ;C\Ù>—\ÓÁŽE%0‚ RM\ZZU­i^R¥…¯SH\ÊvÊ¬i™\Êb±À[4\Ý­\ÎÒ‡ ƒS ôam¿\nº”8·¥§\àJ´Z	\Ù\ãtjÅ¡dÁ³g[\r¤I…&Q‘ !ð’-2to9—X»4©ñpñK³9sòWs\ÑU®¹½Ãƒ±\á2N\ãg\Èn†•\È\Ô;9\æ­z\î.ð\ã n\0\0‰Ž³Œú-VMHxœøGð–µJüG†O‡ó	Ÿ³œ#„nqôON5\0\Ø\ÝÊ†\í1€4]°1½ºa,˜\í…óˆP•\áj\ÑE5\Ú„R\ÓI0–*ª³Q\Æ5[3J¡<‰øÖ«z\Ü@\ÜÝ¿É§vŸ²\'\Û[b$ šX.öþZ>\é\Õ.P±	GŒ\èeÐ¯»ºp\ëñ÷º%Æ \ÑrKJ¾y‰øI\Â%ª]¼0L}\Ð\'‘™uc–¹­S\á9–\\\Ö£ˆ\ÚTk\\\Ôq\ÉU¶š$!\Å\ÉÙ¥•\Ó‹X	K´­\ÑKy	|ð\ä©Š¦tm&\èm\Õ¦Z’ô\ÊeeP\ØeÁP\ÂVƒ\ÝV[•u+‘”>ö\ê!÷Rfh…g‰4FÊˆ!,Q\âs%´¬@…o\ÊôCu[ H…\ËûuªPµ¿¥²wÁ€÷£^]ž\éÁ¦pI\Äü\×1ÿ\0ú5 o\0€[^\"Q¼lŠSH$Y\Ï\ÍÃ¦gœ’y”\ã\ØÚ¢£\ãh#	>½=€nœ»Lž¥§\êSÈ¯¦^\æ?\Ñ 	q\0u8V6þ™ý.iô!\ÖnZÁ§\ÆN\0\"}€üó\ê–M\Z¦·viÒ¤\àr |E\ã\0tž<nHvYT^ÎŒËTk]\îƒ\è¼F8–\ÝN\Ó\0uX\Ø]+v\å\Ü4©\Ïù8†„B\ã\Ë|A“þ.?p–¯ô>&¸‘/ðIðp€D@ç±Ÿ%=/F ·…\Ïa_\â.k‰8¤\à\é=œW°<Ÿ*£\Þ\×P(?\È=BI\Ð1ƒ»Áœ@þ|G×­¢Þ \çÀ\ï¡\\²‹¤À0p[þ¡=þ\è˜wgU$\Ëû\Â\Ç{}N~\Å0h\Ï&› ƒ´óH1”\Z÷\Æ\î8\ÃÀ.Ãºq>è¦Š\à\×N\0ƒöŸ\ÎJòn6\n+tWªhÁ„šs\Úw‡š\Üó	«Q®bG¨?Ä¡\ÖÖ ’|Ð£“[“\ZOFZd\0L¶:/4\Û\0\nk¢Öµ¨3Ì¹q*1=Ó¬ƒ@i¹µ…M½\èœ-\Ô\åÛ¬\É+Ñ»Tm\éI•xù¡\×u@\n‹+üú.j‹j\Ð;\Z)\Ò…h\ÆšWü¥\\\Û\Ä\Ze\Ú¾˜p\á\ëÏ¢H\í\æ \ÓM´\à\Z€\çœ‰X%5\Ü\ß9”\\\æ\Ç‚vh\ãžH\\\×Ti=ã¤¸šñs=ÙŸ<®—…]°°Zª:Ÿ?4\áØ€LUIi§\Å+\ÞZ€sŸª÷G\×*\ÛqÁi\Éië´‚»#\Î‰Žjùš¥\0ñ°TQÒ€\ä–‘|×±¯8=•}\íøkRttj\È5 <‹e\ë0„\ØVŸ>}k«º|&\\\Å\é–ÑžƒZ\á\É\\\Ê\0rA*:©HÈŒù­\Öú—S’ö_fn\Ð?úOÿ\0K¾‹ð€[;9 ƒ\ÒyüB\ê}¢¯ý*‡ü]ô+——7€ò\ËON£Óšc\Ç\é‰ù=£mpCXIñ\0Dò&gó\Õ_cXqrO#ñVjÀ¦Ý­ù\àý•L˜sH‚8Á8+]\ÄSj††q’e û\Î\ÒPûk\Øn\ÙZ&‘™\È\æ#¯\Å#F2ÿ\0f\ËPvW\ßk¡­‰\Ê_h\Ê\ÏqL“Uûh¹[±‚\ÃS$‚&\nz\ãv/	6\ÇIqµQ\ÓIW7\Í—üKN“lH”¿m.z{Ò©,T©Q³+-‹wZ8J\ÝqJT\r$´±2p£fž\àXA\0‚:´\ïüû.]¬\×4Ï„@\â0<‰\É>etš>¼’\0\"3Ó™\\\ïY¦]S<9#–ò™ñ#\Å\ìb\â/\Þ]q4†G²Y¿E®\î³H³5ñ\ËòZ:@\'¶?öP.·\àœ\Ó%¾\Ç-ú‘\ì\Ôf¡†ýJç½–½4«O\ít5\Ã\è}§\æWMµ¨\Ó\0\ä.~xñŸ\ä\éxÓ¼dslö~¶¸yx†<Â¡½\Ì\ÏxOøÁ?U²Ö˜·¨]L45Çˆ´¶X] \Ìr8\Ý§¯†h‡\0D‰ˆ=/Š\Ôa\ì3\ç\é_ö­{MŒ.pxh<\"=–\nñ\Ä\Î&ƒ˜p-?‰Wq¬\á\Þ8¾6[<-\';©\Ý7¢\ÎD½Z\ìV\íE~\n	?¶©Àú¤	ò2?¢`\íµ\ïû¦™Ë¼\ÈòTM·/007q\ä\Z7Ÿ\ÎI¬1\ãg?<ùe×£m\åb\æƒ8q3ùÿ\0ª°\Ó2Ö GSþÒ¾®\Ð\à\î°}\Ï\çUfš\é\ròÀ=\"0|¶TôŠö6¾ÈŠ-q\ã\0ŽE¤KHôˆ÷A\ÝlALVõK©RkŒž6ð\Ì\Ï—\ìD\í\0cXÞ¨\ÎE±8\Û’\ÖL²lÔ´˜a0—ô­=\Åó•r\èV˜d,U\ë	\Â;R\Ê\ØC\éD”£…=™iŠ\ÚP\0\Ên±y‰JZ{O“F†¦-„N‘¬<¯I*^7^ñË¡fP¥e\ÙÇ’E1\0x÷\Ü=\"¹K}¥cIhˆ’b:c\Ø}“§ƒs‰óÌŸ\"#\àj”Þ’\æÀ#\ÄFDN\í¼!\ã\ÓKG=\Ô(AY\Ø\Â\îñFµº5p1>\Ý4-x] l>d.Œgñx\îZ(³€\à9ƒòOv7q·\Ñ\'ºØº ú\É\Ù´®G‡=’ù¾Cx>::³\Û\ÕKþ\Î\Ý\å-iš“™¶GNa:\ãO’¤3¿AzMn\Éo¶š\ãm\éžýGH`ó\ê|‚º\ã] \Ê\æ}£»uZ¥\Î3ù\ÉT\ä/žn3P¨aÀ‚]Sg’K\âw\'ª¶\Úgºi\Æ\î?\Ü|ü‡EŽRK\ZN\Zp:I\Ê$\Ølð\ïûˆ\ÉM\ËB0Ùº‹›1É¢?=\Éù*\ìA;y&9aª‹&\ï)$ûmù\æ·\é\Ô\ÚK ÿ\0–\ÇvÜœ\0:-La\Ñk;v´¿‡\0	\Ìo¢\è:{›R›6øˆJœ\Ó)1\Ä~¬\Ò#¤Ì(MT\ê2#vI´f\í\Ø\á\áœ*´: \0—u}BjB3£\Ü`-\ß\Üj.†\ì–8ÀqE\ïnx°ƒÔ§œ,M¦Z‹\í¢FT¿\ëóa+5]-÷10Ù‰·\ä{²\Ö/¦\Ã\Âq7\âq;\"½‘\ì#kEk‰§ÀÁƒR9“É¼¼þ½F…£\ÐÖ€\Z\Ñ£\0\Êo7’6ú3ÊŽyq\ÙZ\äL\0Ã¤ô\ßo>I3µu\ØÁþ \æ‚\Ðg#ž9®\ï]\á­%(v“O\ïm\Ëy¸O“¦~ªß\Ðxf}ŸupCš9Dz,´®‹pAú\ãu¤ŠL{\\8_\ã\ÌF#\ÈO\Å,ŸÓ¼cý\ÕBiª\à\î\Ñk\×\Æñ\ä`\É½>ke•†d™#\Ì\í\ÊB£M¡1\Í Lò o\èF\nc§a\äIÀ\È\ß\ÖPòJ´ƒ\ã\í™-Y“\Ó\Ï\Ù_Q°ˆ\\l³]Q\Â^\íŒ.7÷	Nþ”\ß{m\à\'\Ó\ê‚\ê6¸Mai\nç‹Aw=€õê®¤\ÉdòüúQ¦\É%±Žªuž\Z\Þ\0g\ÏË¢e\ìI*5[?ô;O\Í2ö>Ö›«Rm_\Ñ\ã\á\å\ÄX\àKOSâŸ‚O±v:zó\Ç\çªz\ì¸p—5\Í$–ƒ¿7‰ þ\×@göù)ª	jÎ¡¨Z5¬.n\Þ~\Ò6òt@n\Û\"\ÓV\ìŠEœEÀþFð\ç…ÃŸ‘R\Ò@q-=$%sä­£J*\è\çŠVû{bÐš_`%{ÿ\0@#dœ¼buz\Ðr«u\ÛG4wP\Ò\ç`„¿D$¢bÌŸe\Æc±ŽH¦‰¥\Õ{AhÖ¹ \É\ë\Ë\×\Ñ}€CõÛ‚ÆŠ`\æ°ÏšS\ÂJS¹z*8\í\Ñu>\Ôð»‡¹­À-w\0Œ6\"‹=rS\Â\ÒC·\áp‚}Ä¤Za_Ý®\Äs\Í\r\ËÇƒC¥\åR\ìrYn[\ák|Ð½3U\é\Ö8ýµ	ù<ýÑ®\à’\á5	©-\nJ™\Ì{[¥\n•«³‹„\Ë_±2K`m\æ^›§–¼‚Zs˜9<Žw]w´zOQWƒ‹\æœq\à¼\ÂJ\ín’\Ç9•­Ák€\á©L´´ˆý.†0}’ÓX\Î9\Ýh\Ø1\Õ<\ê\íþC\æŒ6ŠMµqŽ \0dõ“²-e]\Ñ\éö#”%˜\Ñi¤²\Ý\ÛH+kœ¼-•’\ì\r\Ý\Ò\Ò2—5¶p‚œkRJ½ §!Ù™\î\"Å™a/C–þÊšôÀ\ç<‰ô\ß\æ´4†ON \0øý\ÖJÀ‘\'sü\Êyvs¥Ñ¢È–¸=±\ÌD‚6 ŽˆžŸT6\áœ<M¦ç·‰¡\Ûf)ÁC(‡´q7–|ÁZ\ìZOü2.+\Ñ\Ô\ëUp\á¦\êœ|#´œ‰#u¯NºŠŒ$\â`û\á+\éW®¨<n\âp‰wQ°?$eŽ\Ç\æë›•rluG\ãC÷v¼p\ÂúÒ¸u6;«G\Ñz\â¸2sŽ„Z3:\ÞWŸôƒ¢\Ø\ØV\0ñ\ä‘(!Z \0“°Iš•\×Ë¿#’7\Ú;\Èþ˜õw\Ø%—\Ññ1ñ‡\'\Ûÿ\0ƒX¡ìµŽW6¢\Ê(¾´&ù5Ô¨Úšj\'ú5\\\ßñÝŸüœeE\Å\ä!µ+9¿EðO°ý>\Ý\Ý\ÕN›ýšHøŸ¢e\Ò5\Zwt»\ÃA³Zx]r$C\îI\ìµ÷q[„˜eHAÿ\0´ý¾\Øó;©0pÇ\Ål!\Ú\r´ˆ¨Áv#û]\ÒzA¤#oTû­³ŠÞ \"q#Õ¤±HÁ²¦h(\ËEa›”vQM§\nEªOÂ”„\å5)\Ê¬ZÒ˜Ð­P`¨ž\ËG4¾£\à\ãøP¸§7v\îþ½Q\ÑPz•Š­#“2yûò]½!ªl›\àL\0¶#ó\ÕYFœ‚\ìƒ\ä¼Ó´ú•\ß\Ý0K\È$f5n€\Ò\ã-Ð´Œ%Si\nÙ»³.$‚1\0qzl\ç4\ßE\ØKz]_™LV\Û$r;–‡c\Z\rºrh´t$|\Ñ:n@;8\ék\Û\Ð\Ï\Ä#”\ÚW;k+LFz“EŽzøVU\Ô\n˜XNžŒ6\r»¸/yq\æUeTÒ¦\\»\çB¨ƒ\Ê\ÃqQh¬\ä:\á\Ë,\Ò3Vt¯(Œ¨’ªmlÀR…\è5}uC\nVƒž§º»\Ã·\ïwö·ù\è®)·HÌšJ\Ø\å¤\Ý÷”šw`#\ÊFG±•58Ò¨`–žBl§\n4KZÁ\rh\á\0t_Uc\\–œuÑ”9F™ÍŽN´s×…A\Âg¾\ìË²i88iÃ½Ž\Ç\ä€^\Ú>™‡°·\Ôc\ã²Nx\å\Ð\ì2F]3;^²_	\nn|,\×U°†\Zûjì¨²¦¦`nzŽ^û¦½CN\ïC\\AkI€\â0\Ó; Ž\Ó*\nŸ\Òa2]Ã˜\âŒ1\æct\ì%ñ¡\\ª¥g\Ú=g[Tmn9k]\È;c>`€´\Òwœ™\'¯3j\Û;;cZ“H\àyejn9k\ç$U#\Æ\èOª\ÎG½“\Ý,©óF¨!ö¬D\é«L3\Ùwÿ\0T·û›ôMNbE²¯\Ý\ÕcúúlSñ \ä.?Ÿ3RûŠfJÊ)Q\îW\Å(º°%•[\ê+±\Ö+Ð³¢F½UŠ¡VT*‡•HÑŠ\î¬N—R|@Ló\Ø@ú­/\Òj\Üxi\ÄOˆ’F:ýŸcj€_Lô~\Èñ\Æ\ÜtYRugšM\Öwö<š?9.…§\Ñe6\nt\Äd\îO2OTM´e\na2wqõ;™’µ5óþû|9£â‚‡\äS.W=zT®…†OUöúª)`yºÿ\0Â¿ ÷)„\0^¿l\çËªð©µY7Z-»ò\êMõß,¬\ìÕ¨\Ït	\Ü\\\áð&ˆ\åðQaU\Æ?bù\É{0\\\Ú5ÍŽ \â1Œ$sB¬\Â\ç[4ôx¶–‰\Æ<—@ª¯ƒ…T£e©4\'v²ýÕ±¦÷\ê³Ç‰Éž}dœ¤º¶ÆGSv\í$e\Ø80GD§\Ûý8nZ7€ÿ\0±\\\ï&|2\Å>šÿ\0h>	\î…\ÛDJ›P‹\'#\åX\â=¨\Ì&­ïŽ–øO¶\ß$¸Z¶örã†©a\Ù\ã£d—›‡ž?ÁŒÑ¸\Ø\Ô\×/A•[Ê7®<q±A9\Ë%b´½\Ëe\èY\Ð3T+;Êº¡V\ÙZx\ã\ëPº*r\â¬f\Ðmƒi°\Ç/œ”d4Ÿ%›IÀ\î\ÐKG.[d\Z\0óõWS¯„*\á{\n\È]J®\î?žA[Eóž«\Ìã’¿\ÉK*M2¦Ò³ñ\ÆŒz»!õf\ç\æ«=%]rvø*Zwø«²Šžs\î¼`\ä¾~\ë\éQ­\î‰V^±µ)\Zn ¬÷†=×¼k‘ú´K\ì\ÂEœ¾½©¥U\Ô\ÝûO\Är(³‘>\ÛY‰efÿ\0¥\ßdÖ¢ž>_©!øK’°«U5	iƒ#\ÙN›°¼ª$#5f\Æ\ëj\ãZ\á±®„³w°\ÓLò\Èô(­J\É(`¦\Ð!B£\ÖZŽS{–w”\ÐÁYcšt~ž)\Ðcy´x½NO\Í/öjÏ½¸l\ì\ßÿ\0\×oœ\'=Iž‚ò5šB¹\åº2\é\ç{¢œ\Ð\ë\nFF7û¢¶\Õ0…uÐ£!\n‡5}¸+\Î\å¡YF*4Ž\ê\ÎjÚ‡¢¨Eu•\í*KC\n¦\ìxVV?!j¸Y\n²ª¯ˆRw#ù*.¬ú¾ÖˆQw‡\ÎG¡B\ÍTöV\ÝÝ·„Ž\ÈÊ£¾Ä®7\êySþ/\ì$˜õj=\å\'0óõ$›|\èž[\\—\Ïþ®»m\Ý\Ö$lìº[ÃšO€\În‹(9\\\í–Z¹\ÏÍ¾+cÜºCG\Ô*¸8r\ß\Ñ¦òs\É/1\Ó\î`p¸À\åü!Í´­\Éuhò¨qWT\n©84’\0÷P+t†~\ÉP\à¦\êœ\Ü`z÷ú#Í«Å…œQ¦\Úcf€=|×¶\ÍñP¹™²N\ÑÌœ\Ûm–[\Ôxql\í1ŒuªÜ»„\æLýŠ¢ˆñû¦‡?_Ï¢ôidš÷\ë#\ë…s©ž„ªIS \ì\Æ\ËTd÷¹q\å\n]\Ç\äê«¯Lþ{ª\ÙH²”C\ÚÚ€n\ÂV‹k¶¼t=\n\Í]ƒ\nŠ”‚›DV-¸tþâ¤\×c–9{­L¥•\å\Í=”{(®\Î\éü.\Ülz¯9Õ€/^0´‘\njS–¬t\ê€3õŠ&\Æ\ËP\Ê\Ô2¹?ªA%ÿ\0F“¢ŽõŽp–\ï·!\rû!ý¡¦\ÃLûN}÷\Ï<­õZ\'aË—M•wV\á\Ì-±\å\Ípñ\å\ã•H\Ô\'R±b‹Y\Î>>\ëXk\í\×R²\Óh¿?\åkîŒ\è‘\Ñ<k¡\\ª…>ªúJ‹2\×Ÿf¨€\ãTò\Ã}y”>¯4OMÿ\0\Æ\ßªWÈ›„4È•D<\ë W”kË£\×\èPv”J\Ëùú+\ÃN¬R;A[Q‘\éöZ(þ£\éô?î¨²\å\éöW\Òý^\Åv6J£T2ŠŠžkL\Éc÷PRrƒÊ¶Q\íq²¤\å]q°ôTEŸSnTnB¹›ª\î~\ê\Ê3€¦í—œ”ù{(C\êûxJ\ÛO’Í«‡Ÿ\Ù!ú’OÇ•ú%ƒÊ“™**L^B24…\Í^\Ð\Ówý\'\äUtj#Ú þ“ý\nX´8^‹\Â\È\å_¡\ì2mPFeD/˜½) \èÿ\Ù','ezgiince@gmail.com','0000');
/*!40000 ALTER TABLE `registrar` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-30 15:46:25
