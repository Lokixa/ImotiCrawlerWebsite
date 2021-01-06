import React, { Component } from 'react';
import Datatable from 'react-bs-datatable'

export class Ads extends Component {
  static displayName = Ads.name;

  constructor(props) {
    super(props);
    this.state = { ads: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderAdsTable(ads) {
    if (ads === null || ads.length < 1) {
      return (
        <p>No entries</p>
      )
    }
    let tempObj = ads[0]

    let header = Reflect.ownKeys(tempObj).map(x => {
      let obj = { title: this.presentString(x), prop: x }
      if ((typeof tempObj[x]) !== 'string' || x === 'activated') {
        obj.sortable = true
      }
      if (x === 'url') {
        obj.cell = (row) => {
          return (
            <a href={row.url}>URL</a>
          )
        }
      }
      return obj
    })

    return (
      <Datatable tableHeaders={header} tableBody={ads} initialSort={{ prop: 'price', isAscending: true }} />
    );
  }
  static presentString(text) {
    return text[0].toString().toUpperCase() + text.substring(1)
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Ads.renderAdsTable(this.state.ads);

    return (
      <div className={'container'}>
        <h1 id="tabelLabel" className={'mb-3 text-center'} >Real Estate Ads</h1>
        <div className="text-center">
          {contents}
        </div>
      </div >
    );
  }

  async populateWeatherData() {
    const response = await fetch('adsinfo');
    let data;
    if (response.ok) {
      data = await response.json();
    }
    else {
      data = null;
    }
    this.setState({ ads: data, loading: false });
  }
}
