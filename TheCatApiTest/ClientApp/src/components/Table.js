import React, { Component } from 'react';

export default class Table extends Component {

    constructor(props) {
        super(props);
    }

    render() {
        const { data } = this.props;
        const { categories } = this.props;

        return (
            <table className='table table-hover' aria-labelledby="tabelLabel">
                <thead>
                    <tr className="filters">
                        <th>
                            <select className="form-control" onChange={e => { this.props.onFilter(e.target.value); }}>
                                <option value="">Select Category</option>
                                {categories.map(category =>
                                    <option value={category.id} key={category.id}>{category.name}</option>
                                )}
                            </select>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(image =>
                        <tr key={image.id}>
                            <td>
                                <a href={image.url} target="_blank"><img src={image.url} height="200" /></a>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
}
