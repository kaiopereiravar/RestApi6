using CriandoApi6.Application.aluno.Response;
using CriandoApi6.Repository;
using CriandoApi6.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriandoApi6.Application.aluno
{
    public class AlunosService : IAlunoService
    {
        private readonly CriandoApi6Context _context;

        public AlunosService(CriandoApi6Context context)
        {
            _context = context;
        }

        public List<TabAlunos> BuscarAlunos()
        {
            var alunos = _context.TabAlunos.ToList();
            if (alunos == null)
            {
                return null;
            }

            return alunos;

        }

        public InserirAlunosResponse InserirAlunos(AlunosRequest request)
        {
            var response = new InserirAlunosResponse();

            try
            {
                var alunoExistente = _context.TabAlunos.FirstOrDefault(a => a.nome == request.nome && a.sobrenome == request.sobrenome);

                if (alunoExistente == null)
                {
                    var aluno = new TabAlunos()
                    {
                        nome = request.nome,
                        sobrenome = request.sobrenome,
                        turma = request.turma,
                    };

                    _context.TabAlunos.Add(aluno);
                    _context.SaveChanges();

                    response.status = true;
                    response.message = $"aluno: {request.nome} inserido com sucesso!!!";
                    return response;
                }
                else
                {
                    response.status = false;
                    response.message = $"Não foi possivel inserir o aluno: {request.nome} pois ele já existe no sistema.";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = "Não foi possivel inserir o aluno, erro durante a requisição, peça ajuda de um profissional para resolver o problema. Error - " + ex.Message.ToString();
                return response;
            }
        }


        public bool AtualizarAlunos(AlunosRequest request, int id)
        {
            try
            {

                var aluno = _context.TabAlunos.FirstOrDefault(x => x.id == id);
                if (aluno == null)
                {
                    return false;
                }

                aluno.nome = request.nome;
                aluno.sobrenome = request.sobrenome;
                aluno.turma = request.turma;

                _context.TabAlunos.Update(aluno);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarAlunos(int id)
        {
            try
            {
                var aluno = _context.TabAlunos.FirstOrDefault(x => x.id == id);
                if (aluno == null)
                {
                    return false;
                }

                _context.TabAlunos.Remove(aluno);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
