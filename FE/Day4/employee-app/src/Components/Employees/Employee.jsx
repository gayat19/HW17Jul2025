export default function Employee(props){
    const like = ()=>{

        props.onLikeClick(props.employee.id)
    }

    return(<div className="card" style={{width: "18rem"}}>
  <div className="card-body">
    <h5 className="card-title">{props.employee.name} </h5>
    <h6 className="card-subtitle mb-2 text-muted">{props.employee.phone}</h6>
    <p className="card-text">{props.employee.email} - {props.employee.department_Name} </p>
    <button className="btn btn-warning" onClick={like}>Like</button>
  </div>
</div>)
}