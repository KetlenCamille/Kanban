# Kanban
<br>
Crie um aplicativo simples (preferencialmente na plataforma que esteja trabalhando atualmente em
outra disciplina) para controle de status de atividades aplicando o conceito de Kanban.
<br>São três status (fases) possíveis:
<br>1. “A FAZER”;
<br>2. “EM EXECUÇÃO”;
<br>3. “CONCLUÍDO”.
<br>
Quando uma atividade é inserida devem ser informados:
<br>• nome da atividade;
<br>• atividade que a precede (pré-requisito);
<br>• a atividade recém inserida na lista recebe sempre o status inicial “A FAZER”.
<br>
O programa irá continuamente permitir:
<br>• Inserção de nova atividade na lista;
<br>• Atualização de status de uma atividade da lista;
<br>
Regra para atualização de status:
Com exceção do status inicial “A FAZER”, uma atividade deve estar sempre com status (fase) anterior ao
seu pré-requisito. Por exemplo: se a atividade A é pré-requisito para a atividade B, a atividade B só poderá
entrar na fase 2 (“EM EXECUÇÃO”) quando a atividade A estiver com na fase 3 (“CONCLUÍDO”).
<br>
O programa deve a qualquer momento exibir a lista de atividades, com seus nomes e o status atual.
