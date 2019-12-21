import React, {Component} from 'react'

const $ = require('jquery')
$.DataTables = require('datatables.net')

class DataTables extends Component{
    constructor(){
        super()
        this.state = {
            data: {}
        }
    }

    componentDidMount(){
        this.renderTable();        
        this.interval = setInterval(() => this.setState(()=>{ this.renderTable(); }), 1000);      
        
        
    }

    renderTable(){
        
        fetch("https://localhost:5001/api/v1/beats")
        .then(response => response.json())
        .then(jsonData=>{

        this.$el = $(this.el)
        this.$el.DataTable( {
            order: [[ 2, "desc" ]],
            destroy: true,
            data: jsonData,
            lengthChange: false,
            searching:false,
            columns: [
                { title: "Id", data: "id", width:"10%"},
                { title: "User Name", data: "beaterId"},
                { title: "Price", data: "price" },
                { title: "Beat time", data: "beatTime", render: function(row, index){
                    var date = new Date(row);
                    return date.toLocaleDateString()+" "+date.toLocaleTimeString();
                }
                },                
            ]
        });

        })
    }

    componentWillUnmount(){
        clearInterval(this.interval);
        this.$el.DataTable.destroy(true);
    }
    render(){
        
        return (
            <div>
                <table id="mainTable" className="table table-striped table-bordered" width="100%" ref={el => this.el = el} ></table>
            </div>
        )
    }
}

export default DataTables

