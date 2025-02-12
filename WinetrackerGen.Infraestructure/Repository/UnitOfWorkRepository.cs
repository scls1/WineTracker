

using WinetrackerGen.ApplicationCore.IRepository.Winetracker;
using WinetrackerGen.Infraestructure.Repository.Winetracker;
using WinetrackerGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinetrackerGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IArticuloRepository ArticuloRepository {
        get
        {
                this.articulorepository = new ArticuloRepository ();
                this.articulorepository.setSessionCP (session);
                return this.articulorepository;
        }
}

public override IComentarioRepository ComentarioRepository {
        get
        {
                this.comentariorepository = new ComentarioRepository ();
                this.comentariorepository.setSessionCP (session);
                return this.comentariorepository;
        }
}

public override IValoracionRepository ValoracionRepository {
        get
        {
                this.valoracionrepository = new ValoracionRepository ();
                this.valoracionrepository.setSessionCP (session);
                return this.valoracionrepository;
        }
}

public override IPedidoRepository PedidoRepository {
        get
        {
                this.pedidorepository = new PedidoRepository ();
                this.pedidorepository.setSessionCP (session);
                return this.pedidorepository;
        }
}

public override IMegustaRepository MegustaRepository {
        get
        {
                this.megustarepository = new MegustaRepository ();
                this.megustarepository.setSessionCP (session);
                return this.megustarepository;
        }
}

public override ILineaPedidoRepository LineaPedidoRepository {
        get
        {
                this.lineapedidorepository = new LineaPedidoRepository ();
                this.lineapedidorepository.setSessionCP (session);
                return this.lineapedidorepository;
        }
}
}
}

