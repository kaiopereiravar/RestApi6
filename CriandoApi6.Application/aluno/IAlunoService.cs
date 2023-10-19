using CriandoApi6.Application.aluno.Response;
using CriandoApi6.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriandoApi6.Application.aluno
{
    public interface IAlunoService
    {
        List<TabAlunos> BuscarAlunos();

        InserirAlunosResponse InserirAlunos(AlunosRequest request);

        bool AtualizarAlunos(AlunosRequest request, int id);

        bool DeletarAlunos(int id);
    }
}
