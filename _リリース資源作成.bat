@echo ****************************************************************
@echo    �����[�X�������W�߂āA�����[�X�p��zip�t�@�C�����쐬���܂��B
@echo ****************************************************************
@echo.

@rem �����[�X�������W�߂�t�H���_���쐬
@set stagingDir=Staging\
md %stagingDir%


@rem �p�b�P�[�W�����郂�W���[�������W
copy "bin\Release\packageProduct.exe"         %stagingDir%    || call :func_show_error "packageProduct.exe"
copy "README.md"        %stagingDir%packageProduct_README.md  || call :func_show_error "README.md"
copy "LICENSE"          %stagingDir%packageProduct_LICENSE    || call :func_show_error "LICENSE"




@rem �p�b�P�[�W������
_GitTools\packageProduct.exe %stagingDir%packageProduct.exe  || call :func_show_error "packageProduct.exe"

rmdir /S /Q %stagingDir%

@rem �I������
@echo.
@echo ***************************************************************
@echo ���ׂĂ̏������������܂����B
@echo.
@echo �����[�X�菇
@echo    release/x.x�̃^�O���쐬����B
@echo    �����[�X�^�C�g����x.x�Ƃ��āAZip�t�@�C����Upload����B
@echo ***************************************************************
Timeout /t 10
exit



@rem ---------------------------------------------
@rem  �ȍ~�A�T�u���[�`��
@rem ---------------------------------------------
:func_show_error
@rem %~1�̂悤�Ƀ`���_������ƃ_�u���N�I�[�g�������B
@echo.
@echo ***************************************************************
@echo   %~1 �̏����Ɏ��s���܂����B
@echo   �����[�X�����̍쐬�������I�����܂��B
@echo ***************************************************************
@pause
exit
@rem ���̏����ɖ߂葱�s����ꍇ��/b�I�v�V�������K�v
@rem exit /b
