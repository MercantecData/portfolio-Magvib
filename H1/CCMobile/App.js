import React from 'react';
import { Button, FlatList, StyleSheet, Text, View, ActivityIndicator } from 'react-native';

export default class App extends React.Component {

  constructor(props){
    super(props);
    this.state ={ isLoading: true}
  } 

  componentDidMount(){
    return fetch('https://075a4571.ngrok.io/creditcards')
      .then((response) => response.json())
      .then((responseJson) => {

        this.setState({
          isLoading: false,
          dataSource: responseJson,
        }, function(){

        });

      })
      .catch((error) =>{
        console.error(error);
      });
  }

  _handlePress = (text) => {
    console.log(text);
  }

  render() {

    if (this.state.isLoading) {
      
      return (
        <View style={styles.container}>
          <ActivityIndicator />
        </View>
      );

    } else {
      return (
        <View style={styles.container}>
          <Text style={styles.text}>Credit Cards</Text>
          {/* <Text>{item}</Text> */}
          <FlatList
          style={styles.text2}
          data={this.state.dataSource}
          renderItem={({item}) => <View style={styles.buttonContainer}><Button style={styles.buttonS} onPress={() => this._handlePress(item)} title={item} color="#841584" /></View>}
          keyExtractor={({id}, index) => id}
          />
          
        </View>
      );

    }

  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#212121',
    alignItems: 'center',
    justifyContent: 'center',
  },
  text: {
    marginTop: 60,
    color: '#FF6F00',
    fontSize: 62,
  },
  text2: {
    color: '#FF6F00',
    marginTop: 20,
  },
  buttonS: {
    margin: 20,
    flexDirection: 'row',
    justifyContent: 'space-between',
  },
  buttonContainer: {
    margin: 20,
  },
});
