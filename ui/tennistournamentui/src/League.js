import React, { Component } from 'react';
import { variables } from "./Variables.js";

export class League extends Component {
    constructor(props) {
        super(props);
        this.state = {
            surfaces: [],
            tournamenttypes: [],
            leagues: [],
            modalTitle: '',
            Name: '',
            Id: 0,
            SurfaceId: 0,
            TournamentTypeId: 0

        }
    }
    refreshList() {
        fetch(variables.API_URL + 'league')
            .then(response => response.json())
            .then(data => {
                this.setState({ leagues: data });
            });
    }
    componentDidMount() {
        this.refreshList();
    }

    changeLeague = (e) => {
        this.setState({ Name: e.target.value })
    }
    changeSurface = (e) => {
        this.setState({ SurfaceId: e.target.value })
    }
    changeTournamentType = (e) => {
        this.setState({ TournamentTypeId: e.target.value })
    }

    addClick() {
        this.setState({
            modalTitle: "Add League",
            Id: 0,
            Name: "",
            SurfaceId: 0,
            TournamentTypeId: 0
        })
    }

    editClick(currentLeague) {
        this.setState({
            modalTitle: "Edit League",
            Id: currentLeague.Id,
            Name: currentLeague.Name,
            SurfaceId: currentLeague.SurfaceId,
            TournamentTypeId: currentLeague.TournamentTypeId
        })
    }
    createClick() {
        fetch(variables.API_URL + 'league', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Name: this.state.Name,
                SurfaceId: this.state.SurfaceId,
                TournamentTypeId: this.state.TournamentTypeId
            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                this.refreshList();
            }, (error) => {
                alert('Failed');
            })
    }
    updateClick() {
        fetch(variables.API_URL + 'league', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Id: this.state.Id,
                Name: this.state.Name,
                SurfaceId: this.state.SurfaceId,
                TournamentTypeId: this.state.TournamentTypeId
            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                this.refreshList();
            }, (error) => {
                alert('Failed');
            })
    }
    deleteClick(id) {
        if (window.confirm('Are you sure?')) {
            fetch(variables.API_URL + 'league/' + id, {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
                .then(res => res.json())
                .then((result) => {
                    alert(result);
                    this.refreshList();
                }, (error) => {
                    alert('Failed');
                })
        }
    }
    render() {
        const {
            surfaces,
            tournamenttypes,
            leagues,
            modalTitle,
            Name,
            Id,
            SurfaceId,
            TournamentTypeId

        } = this.state;
        return (
            <div>

                <button type="button"
                    className="btn btn-primary m-2 float-end"
                    data-bs-toggle="modal"
                    data-bs-target="#exampleModal"
                    onClick={() => this.addClick()}>
                    Add League
                </button>

                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>
                                League Id
                            </th>
                            <th>
                                Name
                            </th>
                            <th>
                                Surface
                            </th>
                            <th>
                                Tournament Type
                            </th>
                            <th>
                                Option
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {leagues.map(lea =>
                            <tr key={lea.Id}>
                                <td>{lea.Id}</td>
                                <td>{lea.Name}</td>
                                <td>{lea.SurfaceName}</td>
                                <td>{lea.TournamentTypeName}</td>
                                <td>

                                    <button type="button"
                                        className="btn btn-light mr-1"
                                        data-bs-toggle="modal"
                                        data-bs-target="#exampleModal"
                                        onClick={() => this.editClick(lea.id)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                            <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                        </svg>
                                    </button>

                                    <button type="button"
                                        className="btn btn-light mr-1"
                                        onClick={() => this.deleteClick(lea.Id)}>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                                            <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                        </svg>
                                    </button>

                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>
                <div className="modal fade" id="exampleModal" tabIndex="-1" aria-hidden="true">
                    <div className="modal-dialog modal-lg modal-dialog-centered">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">{modalTitle}</h5>
                                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div className="modal-body">
                                <div className="input-group mb-3">
                                    <span className="input-group-text">League Name</span>
                                    <input type="text" className="form-control" value={Name} onChange={this.changeLeague} />
                                </div>

                                <div className="input-group mb-3">
                                    <span className="input-group-text">Surface</span>
                                    <select className="form-select"
                                        onChange={this.changeSurface}
                                        value={SurfaceId}>
                                        {surfaces.map(surface => <option key={surface.Id}>
                                            {surface.Name}
                                        </option>)}
                                    </select>
                                </div>

                                <div className="input-group mb-3">
                                    <span className="input-group-text">Tournament Type</span>
                                    <select className="form-select"
                                        onChange={this.changeTournamentType}
                                        value={TournamentTypeId}>
                                        {tournamenttypes.map(tournamenttypes => <option key={tournamenttypes.Id}>
                                            {tournamenttypes.Name}
                                        </option>)}
                                    </select>
                                </div>

                                {Id === 0 ?
                                    <button type="button"
                                        className="btn btn-primary float-start"
                                        onClick={() => this.createClick()}
                                    >Create</button>
                                    : null
                                }
                                {Id !== 0 ?
                                    <button type="button"
                                        className="btn btn-primary float-start"
                                        onClick={() => this.updateClick()}
                                    >Update</button>
                                    : null
                                }
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}