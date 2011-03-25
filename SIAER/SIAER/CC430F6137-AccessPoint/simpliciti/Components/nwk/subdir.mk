################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../simpliciti/Components/nwk/nwk.c \
../simpliciti/Components/nwk/nwk_QMgmt.c \
../simpliciti/Components/nwk/nwk_api.c \
../simpliciti/Components/nwk/nwk_frame.c \
../simpliciti/Components/nwk/nwk_globals.c 

OBJS += \
./simpliciti/Components/nwk/nwk.obj \
./simpliciti/Components/nwk/nwk_QMgmt.obj \
./simpliciti/Components/nwk/nwk_api.obj \
./simpliciti/Components/nwk/nwk_frame.obj \
./simpliciti/Components/nwk/nwk_globals.obj 

C_DEPS += \
./simpliciti/Components/nwk/nwk.pp \
./simpliciti/Components/nwk/nwk_QMgmt.pp \
./simpliciti/Components/nwk/nwk_api.pp \
./simpliciti/Components/nwk/nwk_frame.pp \
./simpliciti/Components/nwk/nwk_globals.pp 

OBJS__QTD += \
".\simpliciti\Components\nwk\nwk.obj" \
".\simpliciti\Components\nwk\nwk_QMgmt.obj" \
".\simpliciti\Components\nwk\nwk_api.obj" \
".\simpliciti\Components\nwk\nwk_frame.obj" \
".\simpliciti\Components\nwk\nwk_globals.obj" 

C_DEPS__QTD += \
".\simpliciti\Components\nwk\nwk.pp" \
".\simpliciti\Components\nwk\nwk_QMgmt.pp" \
".\simpliciti\Components\nwk\nwk_api.pp" \
".\simpliciti\Components\nwk\nwk_frame.pp" \
".\simpliciti\Components\nwk\nwk_globals.pp" 

C_SRCS_QUOTED += \
"../simpliciti/Components/nwk/nwk.c" \
"../simpliciti/Components/nwk/nwk_QMgmt.c" \
"../simpliciti/Components/nwk/nwk_api.c" \
"../simpliciti/Components/nwk/nwk_frame.c" \
"../simpliciti/Components/nwk/nwk_globals.c" 


# Each subdirectory must supply rules for building sources it contributes
simpliciti/Components/nwk/nwk.obj: ../simpliciti/Components/nwk/nwk.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\Access Point\smpl_config.dat" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat"  -vmspx -g --define=__CC430F6137__ --define=_CCE_ --define=MRFI_CC430 --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --diag_warning=225 --printf_support=minimal --preproc_with_compile --preproc_dependency="simpliciti/Components/nwk/nwk.pp" --obj_directory="simpliciti/Components/nwk" $(GEN_OPTS_QUOTED) $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")
	@echo 'Finished building: $<'
	@echo ' '

simpliciti/Components/nwk/nwk_QMgmt.obj: ../simpliciti/Components/nwk/nwk_QMgmt.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\Access Point\smpl_config.dat" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat"  -vmspx -g --define=__CC430F6137__ --define=_CCE_ --define=MRFI_CC430 --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --diag_warning=225 --printf_support=minimal --preproc_with_compile --preproc_dependency="simpliciti/Components/nwk/nwk_QMgmt.pp" --obj_directory="simpliciti/Components/nwk" $(GEN_OPTS_QUOTED) $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")
	@echo 'Finished building: $<'
	@echo ' '

simpliciti/Components/nwk/nwk_api.obj: ../simpliciti/Components/nwk/nwk_api.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\Access Point\smpl_config.dat" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat"  -vmspx -g --define=__CC430F6137__ --define=_CCE_ --define=MRFI_CC430 --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --diag_warning=225 --printf_support=minimal --preproc_with_compile --preproc_dependency="simpliciti/Components/nwk/nwk_api.pp" --obj_directory="simpliciti/Components/nwk" $(GEN_OPTS_QUOTED) $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")
	@echo 'Finished building: $<'
	@echo ' '

simpliciti/Components/nwk/nwk_frame.obj: ../simpliciti/Components/nwk/nwk_frame.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\Access Point\smpl_config.dat" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat"  -vmspx -g --define=__CC430F6137__ --define=_CCE_ --define=MRFI_CC430 --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --diag_warning=225 --printf_support=minimal --preproc_with_compile --preproc_dependency="simpliciti/Components/nwk/nwk_frame.pp" --obj_directory="simpliciti/Components/nwk" $(GEN_OPTS_QUOTED) $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")
	@echo 'Finished building: $<'
	@echo ' '

simpliciti/Components/nwk/nwk_globals.obj: ../simpliciti/Components/nwk/nwk_globals.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\Access Point\smpl_config.dat" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat"  -vmspx -g --define=__CC430F6137__ --define=_CCE_ --define=MRFI_CC430 --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --diag_warning=225 --printf_support=minimal --preproc_with_compile --preproc_dependency="simpliciti/Components/nwk/nwk_globals.pp" --obj_directory="simpliciti/Components/nwk" $(GEN_OPTS_QUOTED) $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")
	@echo 'Finished building: $<'
	@echo ' '


