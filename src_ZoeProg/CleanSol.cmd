:: ###################################################################################
:: #
::                        		ChocolateyNuGet project @ Ghislain 
:: #
:: ##					 Remove  all obj and bin Folder from this Project.
:: #:: 
:: #
:: #
:: ##################################################################################




FOR /F "tokens=*" %%G IN ('DIR /B /AD /S bin') DO RMDIR /S /Q "%%G"
FOR /F "tokens=*" %%G IN ('DIR /B /AD /S obj') DO RMDIR /S /Q "%%G"


ECHO OFF Pause