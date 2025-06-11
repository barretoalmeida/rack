configurando a interface serial Router 2911
Grupo-01

!Acessando o modo Exec Privilegiado
enable

  !Acessar modo de configuração global
  configure terminal

    !Configuração da interface Serial0/0/0 DCE (Data Circuit-Terminating Equipment)
    interface serial 0/0/0

      !Descrição da Interface Serial DCE
      !OBSERVAÇÃO IMPORTANTE: veja o arquivo 00-DocumentacaoDaRede.txt a partir da linha: 232
      !(SÉTIMA ETAPA: Determinação da Interface Serial de WAN dos Grupos e seu Endereçamento IPv4)
      description Interface Serial do Grupo-??? para Grupo-???

      !Configuração do endereçamento IPv4 da Interface Serial DCE
      !Verificar a tabela de endereçamento IPv4 dos Grupos
      !Sempre vai ser o Endereço IPv4 IMPAR na Interface Serial 0/0/0
      ip address 192.168.1.1 255.255.255.252

      !Configurando o Clock Rate (Velocidade do Link) para 2000000bps (2.0 Mbps)
      clock rate 2000000

      !Configurando a Largura de Banda (Dividir o Clock Rate por 1000 para achar o valor em Mbps)
      bandwidth 2000

      !Habilitando a interface Serial DCE
      no shutdown

      !Saindo das configurações da interface
      exit

    !Configuração da interface Serial0/0/1 DTE (Data Terminal Equipment)
    interface serial 0/0/1

      !Descrição da Interface Serial DTE
      !OBSERVAÇÃO IMPORTANTE: veja o arquivo 00-DocumentacaoDaRede.txt a partir da linha: 232
      !(SÉTIMA ETAPA: Determinação da Interface Serial de WAN dos Grupos e seu Endereçamento IPv4)
      description Interface Serial do Grupo-??? para Grupo-???

      !Configuração do endereçamento IP Interface Serial DTE
      !Verificar a tabela de endereçamento IPv4 dos Grupos
      !Sempre vai ser o Endereço IPv4 PAR na Interface Serial 0/0/1
      ip address 192.168.1.22 255.255.255.252

      !Configurando a Largura de Banda (Dividir o Clock Rate por 1000 para achar o valor em Mbps)
      bandwidth 2000

      !Habilitando a interface Serial DTE
      no shutdown

      !Saindo das configurações da interface
      end

  !Salvando as configurações
  copy running-config startup-config

  !Visualizando as configurações
  show running-config

  !Visualizando as configurações de endereçamento IPv4
  show ip interface brief

  !Visualizando as informações de Roteamento
  show ip route

  !TESTANDO A COMUNICAÇÃO ENTRE O VIZINHOS DAS INTERFACES SERIAIS
  !ROUTER VIZINHO-DCE-0/0/0 <---> DTE-0/0/1_SEU_ROUTER_DCE-0/0/0 <---> 0/0/1-DTE-ROUTER VIZINHO

  !Pingar a SUA Interface Serial 0/0/0 DCE (SEMPRE SERÁ O ENDEREÇO IPv4 IMPAR)
  ping 192.168.1.1 (serial 0/0/0)

  !Pingar a SUA Interface Serial 0/0/1 DTE (SEMPRE SERÁ O ENDEREÇO IPv4 PAR)
  ping 192.168.1.22 (serial 0/0/1)

  !Pingar a Interface Serial 0/0/1 do SEU VIZINHO DTE (SEMPRE SERÁ O ENDEREÇO IPv4 PAR)
  ping 192.168.1.2 (serial 0/0/1)

  !Pingar a Interface Serial 0/0/0 do SEU VIZINHO DCE (SEMPRE SERÁ O ENDEREÇO IPv4 IMPAR)
  ping 192.168.1.5 (serial 0/0/0)